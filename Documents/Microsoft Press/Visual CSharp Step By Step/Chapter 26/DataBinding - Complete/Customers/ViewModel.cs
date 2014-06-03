using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers
{
    class ViewModel
    {
        private int currentCustomer;

        private List<Customer> customers;
        public Customer Current
        {
            get { return this.customers[currentCustomer]; }
        }

        public void Next()
        {
            if (this.customers.Count - 1 > this.currentCustomer)
            {
                this.currentCustomer++;
            }
        }

        public void Previous()
        {
            if (this.currentCustomer > 0)
            {
                this.currentCustomer--;
            }
        }

        public ViewModel()
        {
            this.currentCustomer = 0;

            this.customers = new List<Customer>
            {
                new Customer {
                    CustomerID = 1, 
                    Title = "Mr.", 
                    FirstName="John", 
                    LastName="Sharp", 
                    EmailAddress="john@contoso.com", 
                    Phone="111-1111"},
                new Customer {
                    CustomerID = 2,
                    Title = "Mrs.", 
                    FirstName="Diana", 
                    LastName="Sharp", 
                    EmailAddress="diana@contoso.com", 
                    Phone="111-1112"},
                new Customer {
                    CustomerID = 3,
                    Title = "Ms.", 
                    FirstName="Francesca", 
                    LastName="Sharp", 
                    EmailAddress="frankie@contoso.com", 
                    Phone="111-1113"
                }
            };
        }
    }
}
