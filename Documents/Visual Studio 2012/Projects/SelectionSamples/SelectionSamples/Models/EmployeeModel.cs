using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectionSample.Models
{
    public class EmployeeModel
    {
        //Custom EmployeeModel Constructor
        public EmployeeModel()
        {
            this.Employees = "johnk";
        }

        //The Employees Property
        public string Employees { get; set; }
    }
}