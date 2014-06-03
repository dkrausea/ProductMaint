using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessApp.BusinessLayer
{
   /// <summary>
   /// 
   /// </summary>
   public class CustomerManager
   {
      public CustomerCollection GetCustomers()
      {
         CustomerCollection result = null;

         result = new CustomerCollection();
         result.Add(new Customer { CustomerId = 1, CompanyName = "Company 1" });
         result.Add(new Customer { CustomerId = 2, CompanyName = "Company 2" });
         result.Add(new Customer { CustomerId = 3, CompanyName = "Company 3" });
         result.Add(new Customer { CustomerId = 4, CompanyName = "Company 4" });
         result.Add(new Customer { CustomerId = 5, CompanyName = "Company 5" });
         result.Add(new Customer { CustomerId = 6, CompanyName = "Company 6" });
         result.Add(new Customer { CustomerId = 7, CompanyName = "Company 7" });
         result.Add(new Customer { CustomerId = 8, CompanyName = "Company 8" });
         result.Add(new Customer { CustomerId = 9, CompanyName = "Company 9" });
         result.Add(new Customer { CustomerId = 10, CompanyName = "Company 10" });
         result.Add(new Customer { CustomerId = 11, CompanyName = "Company 11" });

         return result;
      }

      public void Insert(Customer entity)
      {

      }

      public void Update(Customer entity)
      {

      }

      public void Delete(Customer entity)
      {

      }

      public Customer Select(int id)
      {
         Customer result = null;

         return result;
      }

      public void SetFilters(string companyNameFilter)
      {
        
      }

      public int NewPrimaryKey { get; set; }
   }
}

