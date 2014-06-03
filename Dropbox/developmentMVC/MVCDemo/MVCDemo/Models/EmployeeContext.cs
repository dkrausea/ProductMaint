using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
   public class EmployeeContext : DbContext
   {
      public DbSet<Department> Departments { get; set; }
      public DbSet<Employee> Employees { get; set; }
   }
}