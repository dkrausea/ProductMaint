using System.ComponentModel.DataAnnotations;

namespace BusinessApp.BusinessLayer.Entities
{
   public class Product
   {
      public int ProductId { get; set; }
      public string ProductName { get; set; }
      public double Price { get; set; }
   }
}
