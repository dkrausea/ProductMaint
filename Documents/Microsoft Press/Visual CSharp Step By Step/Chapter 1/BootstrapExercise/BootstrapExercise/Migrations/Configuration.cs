namespace BootstrapExercise.Migrations
{
   using System;
   using System.Collections.Generic;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;
   using BootstrapExercise.Models;

   internal sealed class Configuration : DbMigrationsConfiguration<BootstrapExercise.DAL.GunContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = false;
      }

      protected override void Seed( BootstrapExercise.DAL.GunContext context )
      {
         var guns = new List<Gun>
         {
         new Gun{SerialNumber = "18342", Make ="Interarms Alexandria, Virginia. USA", Model = "Virginian Dragoon", Caliber = ".44 Magnum", Type = "Revolver"},
         new Gun{SerialNumber = "56784", Make = "Hawes Firearms Co.", Model = "Western Six Shooter", Caliber = ".22", Type = "Revolver"},
         new Gun{SerialNumber = "10-63928", Make = "Strum, Ruger & Co. INC.", Model = "Mark I", Caliber = ".22 Long Rifle", Type = "Automatic Pistol"},
         new Gun{SerialNumber = "P015888", Make = "Mosburg", Model = "500A", Caliber = "12 GA", Type = "Pump Shot Gun" }
         };
         guns.ForEach(g => context.Guns.AddOrUpdate(s => s.SerialNumber, g));
         context.SaveChanges();

         //  This method will be called after migrating to the latest version.

         //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
         //  to avoid creating duplicate seed data. E.g.
         //
         //    context.People.AddOrUpdate(
         //      p => p.FullName,
         //      new Person { FullName = "Andrew Peters" },
         //      new Person { FullName = "Brice Lambson" },
         //      new Person { FullName = "Rowan Miller" }
         //    );
         //
      }
   }
}
