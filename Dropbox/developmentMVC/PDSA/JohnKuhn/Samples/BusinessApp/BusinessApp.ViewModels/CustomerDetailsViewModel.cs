using System;
using BusinessApp.BusinessLayer;
using System.ComponentModel.DataAnnotations;
using BusinessApp.Framework.Exceptions;

namespace BusinessApp.ViewModels
{
   public class CustomerDetailsViewModel
   {
      public void Load( int customerId )
      {
         CustomerManager manager = new CustomerManager();
         Customer customer = manager.Select(customerId);

         this.CustomerId = customer.CustomerId;
         this.CompanyName = customer.CompanyName;
         this.WebsiteURL = customer.WebsiteURL;
         this.CreditLimit = customer.CreditLimit;
         this.ConcurrencyValue = customer.ConcurrencyValue;
      }

      public void Insert()
      {
         try
         {
            CustomerManager manager = new CustomerManager();
            Customer customer = new Customer();

            customer.CustomerId = this.CustomerId;
            customer.CompanyName = this.CompanyName;
            customer.WebsiteURL = this.WebsiteURL;
            customer.CreditLimit = this.CreditLimit.Value;
            customer.InsertDate = DateTime.Now;
            customer.InsertName = this.InsertName;
            customer.UpdateDate = customer.InsertDate;
            customer.UpdateName = this.InsertName;

            manager.Insert(customer);

            this.CustomerId = manager.NewPrimaryKey;
         }
         catch (Exception ex)
         {
            ExceptionHandler handler = new ExceptionHandler();
            handler.Publish(ex);
         }
      }

      public void Update()
      {
         CustomerManager manager = new CustomerManager();
         Customer customer = new Customer();

         customer.CustomerId = this.CustomerId;
         customer.CompanyName = this.CompanyName;
         customer.WebsiteURL = this.WebsiteURL;
         customer.CreditLimit = this.CreditLimit.Value;
         customer.UpdateDate = DateTime.Now;
         customer.UpdateName = this.UpdateName;
         customer.ConcurrencyValue = this.ConcurrencyValue;

         manager.Update(customer);
      }

      public void Delete()
      {
         CustomerManager manager = new CustomerManager();
         Customer customer =
            new Customer
            {
               CustomerId = this.CustomerId,
               ConcurrencyValue = this.ConcurrencyValue
            };
         manager.Delete(customer);
      }

      public int CustomerId { get; set; }

      [Display(Name = "Company Name")]
      [Required(ErrorMessage = "Company name is required")]
      public string CompanyName { get; set; }

      [Display(Name = "Website URL")]
      [StringLength(64)]
      [RegularExpression("^([a-zA-Z0-9]([a-zA-Z0-9\\-]{0,61}[a-zA-Z0-9])?\\.)+[a-zA-Z]{2,6}$",
     ErrorMessage = "Invalid URL.")]
      public string WebsiteURL { get; set; }

      [Display(Name = "Credit Limit")]
      [Required(ErrorMessage = "Credit limit is required.")]
      [DataType(DataType.Currency, ErrorMessage = "Credit limit must be numeric.")]
      public double? CreditLimit { get; set; }

      public short ConcurrencyValue { get; set; }

      public string InsertName { get; set; }
      public string UpdateName { get; set; }

      public Customer MyCustomer { get; set; }
   }
}
