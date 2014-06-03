﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
   public class Department
   {
      public int DepartmentID { get; set; }
      public string  Name { get; set; }
      public List<Employee> Employees { get; set; }
   }
}