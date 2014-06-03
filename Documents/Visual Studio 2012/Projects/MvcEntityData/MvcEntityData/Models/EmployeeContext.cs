using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcEntityData.Models
{
    public class EmployeeContext : DbContext

    {
        public DbSet<Employee> Employees { get; set; }
    }
}

// The purpous of DbContext class is to establish a connection to our database.
//DbSet returns a set of Employees from the database