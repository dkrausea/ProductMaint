using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectionSample.Models
{
   public class EmployeeModel
   {
      public EmployeeModel()
      {
         this.Employees = "johnk,johnb";
      }

      public string Employees { get; set; }
   }
}