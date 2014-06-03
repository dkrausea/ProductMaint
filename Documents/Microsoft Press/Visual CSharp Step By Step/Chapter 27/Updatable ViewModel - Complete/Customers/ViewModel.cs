using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Services.Client;
using Customers.CustomersService;
using System.Text.RegularExpressions;


namespace Customers
{
    public class ViewModel : INotifyPropertyChanged
    {
        private List<Customer> customers;
        private int currentCustomer;
        public Command NextCustomer { get; private set; }
        public Command PreviousCustomer { get; private set; }
        public Command FirstCustomer { get; private set; }
        public Command LastCustomer { get; private set; }
        public Command AddCustomer { get; private set; }
        public Command EditCustomer { get; private set; }
        public Command DiscardChanges { get; private set; }
        public Command SaveChanges { get; private set; }
        private AdventureWorksEntities connection = null;
        private string url = "http://localhost:53923/AdventureWorks.svc";

        public ViewModel()
        {
            this.currentCustomer = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;
            this.NextCustomer = new Command(this.Next, () => { return this.CanBrowse && this.customers.Count > 0 && !this.IsAtEnd; });
            this.PreviousCustomer = new Command(this.Previous, () => { return this.CanBrowse && this.customers.Count > 0 && !this.IsAtStart; });
            this.FirstCustomer = new Command(this.First, () => { return this.CanBrowse && this.customers.Count > 0 && !this.IsAtStart; });
            this.LastCustomer = new Command(this.Last, () => { return this.CanBrowse && this.customers.Count > 0 && !this.IsAtEnd; });
            this.AddCustomer = new Command(this.Add, () => { return this.CanBrowse; });
            this.EditCustomer = new Command(this.Edit, () => { return this.CanBrowse; });
            this.DiscardChanges = new Command(this.Discard, () => { return this.CanSaveOrDiscardChanges; });
            this.SaveChanges = new Command(this.Save, () => { return this.CanSaveOrDiscardChanges; });
        }

        #region Methods for fetching and updating data

        // Create a new (empty) customer and put the form into Adding mode
        private void Add()
        {
            Customer newCustomer = new Customer { CustomerID = 0 };
            this.customers.Insert(currentCustomer, newCustomer);
            this.IsAdding = true;
            this.OnPropertyChanged("Current");
        }

        // Edit the current customer 
        // - save the existing details of the customer
        //   and put the form into Editing mode
        private Customer oldCustomer;

        private void Edit()
        {
            this.oldCustomer = new Customer();
            this.CopyCustomer(this.Current, this.oldCustomer);
            this.IsEditing = true;
        }

        // Discard changes made while in Adding or Editing mode
        // and return the form to Browsing mode
        private void Discard()
        {
            // If the user was adding a new customer, then remove it
            if (this.IsAdding)
            {
                this.customers.Remove(this.Current);
                this.OnPropertyChanged("Current");
            }

            // If the user was editing an existing customer, then restore the saved details
            if (this.IsEditing)
            {
                this.CopyCustomer(this.oldCustomer, this.Current);
            }

            this.IsBrowsing = true;
            this.LastError = String.Empty;
        }

        // Save the new or updated customer back to the WCF Data Service
        // and return the form to Browsing mode
        private async void Save()
        {
            // Validate the details of the Customer
            if (this.ValidateCustomer(this.Current))
            {
                // Only continue if the customer details are valid
                this.IsBusy = true;

                // Set the ModifiedDate for the customer 
                // to record the date the changes were made
                this.Current.ModifiedDate = DateTime.Today;

                // If the user is creating a new customer, 
                // add it to the collection for the WCF Data Service
                if (this.IsAdding)
                {
                    this.Current.rowguid = Guid.NewGuid();
                    this.connection.AddToCustomers(this.Current);
                }

                // If the user is editing the current customer,
                // update it in the collection for the WCF Data Service
                if (this.IsEditing)
                {
                    this.connection.UpdateObject(this.Current);
                }

                // Save the changes back to the data source
                try
                {
                    await Task.Factory.FromAsync(
                        this.connection.BeginSaveChanges(null, null),
                        async (result) => this.connection.EndSaveChanges(result));

                    this.IsBrowsing = true;
                    this.OnPropertyChanged("Current");
                }
                catch (DataServiceRequestException dsre)
                {
                    if (this.IsAdding)
                    {
                        this.connection.DeleteObject(this.Current);
                    }
                    this.LastError = dsre.Message;
                }
                finally
                {
                    this.IsBusy = false;
                }
            }
        }

        // Helper method to validate customer details
        private bool ValidateCustomer(Customer customer)
        {
            string validationErrors = string.Empty;
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                hasErrors = true;
                validationErrors = "First Name must not be empty\n";
            }

            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                hasErrors = true;
                validationErrors += "Last Name must not be empty\n";
            }

            // Email address is a series of characters that do not include a space or @
            // followed by @
            // followed by a series of characters that do not include a space or @
            // followed by .
            // followed by a series of characters that do not include a space or @
            Regex emailRegex = new Regex(@"^[^@ ]+@[^@ ]+\.[^@ ]+$");
            if (string.IsNullOrWhiteSpace(customer.EmailAddress) ||
                !emailRegex.IsMatch(customer.EmailAddress))
            {
                hasErrors = true;
                validationErrors += "Invalid Email Address\n";
            }

            // Phone number is a series of digits, brackets, spaces, +, and - characters
            Regex phoneRegex = new Regex(@"^[0-9\(\)\/+ \-]+$");
            if (string.IsNullOrWhiteSpace(customer.Phone) ||
                !phoneRegex.IsMatch(customer.Phone))
            {
                hasErrors = true;
                validationErrors += "Invalid Phone Number\n";
            }

            this.LastError = validationErrors;
            return !hasErrors;
        }

        // Utility method for copying the details of a customer
        private void CopyCustomer(Customer source, Customer destination)
        {
            destination.CompanyName = source.CompanyName;
            destination.CustomerID = source.CustomerID;
            destination.EmailAddress = source.EmailAddress;
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.MiddleName = source.MiddleName;
            destination.ModifiedDate = source.ModifiedDate;
            destination.NameStyle = source.NameStyle;
            destination.PasswordHash = source.PasswordHash;
            destination.PasswordSalt = source.PasswordSalt;
            destination.Phone = source.Phone;
            destination.rowguid = source.rowguid;
            destination.SalesPerson = source.SalesPerson;
            destination.Suffix = source.Suffix;
            destination.Title = source.Title;
        }

        public async Task GetData()
        {
            try
            {
                this.IsBusy = true;
                this.IsBrowsing = true;
                this.connection = new AdventureWorksEntities(new Uri(this.url));

                var query = await Task.Factory.FromAsync(
                    this.connection.Customers.BeginExecute(null, null),
                    (result) => this.connection.Customers.EndExecute(result));

                this.customers = query.ToList();
                this.currentCustomer = 0;
                this.OnPropertyChanged("Current");
                this.IsAtStart = true;
                this.IsAtEnd = (this.customers.Count == 0);
                this.LastError = String.Empty;
            }
            catch (DataServiceQueryException dsqe)
            {
                this.LastError = dsqe.Message;
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        #endregion

        #region Properties for "busy" and error message handling

        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set
            {
                this._isBusy = value;
                this.OnPropertyChanged("IsBusy");
            }
        }

        private string _lastError = null;
        public string LastError
        {
            get { return this._lastError; }
            private set
            {
                this._lastError = value;
                this.OnPropertyChanged("LastError");
            }
        }

        #endregion

        #region Properties for managing the edit mode

        // Manage the edit mode of the form - is the user browsing, adding a customer, or editing a customer
        private enum EditMode { Browsing, Adding, Editing };
        private EditMode editMode;
        public bool IsBrowsing
        {
            get { return this.editMode == EditMode.Browsing; }
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Browsing;
                }
                this.OnPropertyChanged("IsBrowsing");
                this.OnPropertyChanged("IsAdding");
                this.OnPropertyChanged("IsEditing");
                this.OnPropertyChanged("IsAddingOrEditing");
            }
        }

        public bool IsAdding
        {
            get { return this.editMode == EditMode.Adding; }
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Adding;
                }
                this.OnPropertyChanged("IsBrowsing");
                this.OnPropertyChanged("IsAdding");
                this.OnPropertyChanged("IsEditing");
                this.OnPropertyChanged("IsAddingOrEditing");
            }
        }

        public bool IsEditing
        {
            get { return this.editMode == EditMode.Editing; }
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Editing;
                }
                this.OnPropertyChanged("IsBrowsing");
                this.OnPropertyChanged("IsAdding");
                this.OnPropertyChanged("IsEditing");
                this.OnPropertyChanged("IsAddingOrEditing");
            }
        }

        public bool IsAddingOrEditing
        {
            get { return this.IsAdding || this.IsEditing; }
        }

        private bool CanBrowse
        {
            get
            {
                return this.IsBrowsing &&
                   this.connection != null;
            }
        }

        private bool CanSaveOrDiscardChanges
        {
            get
            {
                return this.IsAddingOrEditing &&
                       this.connection != null;
            }
        }

        #endregion

        #region Methods and properties for navigation commands

        private bool _isAtStart;
        public bool IsAtStart
        {
            get { return this._isAtStart; }
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged("IsAtStart");
            }
        }

        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get { return this._isAtEnd; }
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged("IsAtEnd");
            }
        }

        public Customer Current
        {
            get
            {
                if (this.customers != null)
                {
                    return this.customers[currentCustomer];
                }
                else
                {
                    return null;
                }
            }
        }
        
        private void Next()
        {
            if (this.customers.Count - 1 > this.currentCustomer)
            {
                this.currentCustomer++;
                this.OnPropertyChanged("Current");
                this.IsAtStart = false;
                this.IsAtEnd = (this.customers.Count - 1 == this.currentCustomer);
            }
        }

        private void Previous()
        {
            if (this.currentCustomer > 0)
            {
                this.currentCustomer--;
                this.OnPropertyChanged("Current");
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentCustomer == 0);
            }
        }

        private void First()
        {
            this.currentCustomer = 0;
            this.OnPropertyChanged("Current");
            this.IsAtStart = true;
            this.IsAtEnd = (this.customers.Count == 0);
        }

        private void Last()
        {
            this.currentCustomer = this.customers.Count - 1;
            this.OnPropertyChanged("Current");
            this.IsAtEnd = true;
            this.IsAtStart = (this.customers.Count == 0);
        }

        #endregion

        #region INotifyPropertyChanged interface

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
