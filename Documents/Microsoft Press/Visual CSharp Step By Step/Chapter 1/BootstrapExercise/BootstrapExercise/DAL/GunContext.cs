using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Configuration;
using BootstrapExercise.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BootstrapExercise.DAL
{
   public class GunContext : DbContext

   {
      public DbSet<Gun> Guns { get; set; }

      protected override void OnModelCreating( DbModelBuilder modelBuilder )
      {
         modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      }

   }
}