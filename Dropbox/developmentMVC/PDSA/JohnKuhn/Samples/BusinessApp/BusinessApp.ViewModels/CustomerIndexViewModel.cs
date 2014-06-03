using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessApp.BusinessLayer;
using System.ComponentModel.DataAnnotations;

namespace BusinessApp.ViewModels
{
   public class CustomerIndexViewModel
   {
      [Display(Name = "Company Name")]
      [StringLength(32)]
      public string CompanyNameFilter { get; set; }

      public CustomerCollection Customers { get; set; }

      public void LoadAll()
      {
         CustomerManager manager = new CustomerManager();
         manager.SetFilters(this.CompanyNameFilter);
         this.Customers = manager.GetCustomers();
      }
   }
}
