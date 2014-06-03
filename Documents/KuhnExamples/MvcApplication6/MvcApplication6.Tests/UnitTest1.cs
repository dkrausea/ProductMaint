using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication6.DataLayer;

namespace MvcApplication6.Tests
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public void TestMethod1()
      {
         using (MvcApplicationContext db = new MvcApplicationContext())
         {
            db.Customers.Add(new Customer
            {
               CustomerId = 2,
               CompanyName = "Qualcomm",
               CreatedBy = "dkrause",
               CreatedDate = DateTime.Now,
               UpdatedBy = "dkrause",
               UpdatedDate = DateTime.Now,
               ConcurrencyId = 0
            });

            db.SaveChanges();
         }
      }

      [TestMethod]
      public void TestMethod2()
      {
         List<DashboardItem> target = null;

         using (MvcApplicationContext db = new MvcApplicationContext())
         {
            target = db.GetDashboardItems();
         }

         Assert.IsTrue(target.Count > 0, "Failed to get dashboard items");
      }
   }
}
