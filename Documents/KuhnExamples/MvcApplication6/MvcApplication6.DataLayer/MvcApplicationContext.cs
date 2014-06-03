using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication6.DataLayer
{
   public class MvcApplicationContext : DbContext, IDisposable
   {      
      /// <summary>
      /// Standard data context DbSet property provides access to customer
      /// table data.
      /// </summary>
      public DbSet<Customer> Customers { get; set; }

      /// <summary>
      /// Create a method in your data context class that calls the stored procedure as shown below.
      /// </summary>
      /// <returns></returns>
      public List<DashboardItem> GetDashboardItems()
      {
         return this.Database
            .SqlQuery<DashboardItem>("EXEC DashboardItemSummary")
            .ToList<DashboardItem>();
      }
   }
   
   /// <summary>
   /// Create a class that represents the values in the rows returned by the stored procedure
   /// </summary>
   public class DashboardItem
   {
      public string DisplayValue { get; set; }
      public int ItemCount { get; set; }
   }

   [Table("Customer")]
   public class Customer
   {
      public int CustomerId { get; set; }
      public string CompanyName { get; set; }
      public string CreatedBy { get; set; }
      public DateTime CreatedDate { get; set; }
      public string UpdatedBy { get; set; }
      public DateTime UpdatedDate { get; set; }
      public short ConcurrencyId { get; set; }
   }
}
