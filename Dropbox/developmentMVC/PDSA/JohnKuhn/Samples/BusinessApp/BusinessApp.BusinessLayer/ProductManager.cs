using System;
using BusinessApp.BusinessLayer.Entities;

namespace BusinessApp.BusinessLayer
{
   /// <summary>
   /// Product business object
   /// </summary>
   public class ProductManager
   {
      /// <summary>
      /// Business object method uses an 
      /// underlying repository to retrieve a collection.
      /// </summary>
      /// <returns></returns>
      public ProductCollection GetAllProducts()
      {
         // This could be using Entity Framework,
         // PDSA Haystack, CSLA or other ORM... 

         // At this level, you shouldn't 'know' or care
         ProductData repository = new ProductData();
         return repository.GetProducts();
      }
   }

   #region Data Repository Class

   internal class ProductData
   {
      public ProductCollection GetProducts()
      {
         ProductCollection result;

         result = new ProductCollection();
         result.Add(new Product { ProductId = 1, ProductName = "eBook", Price = 19.95 });
         result.Add(new Product { ProductId = 2, ProductName = "Utilities", Price = 59.95 });
         result.Add(new Product { ProductId = 3, ProductName = "Haystack", Price = 499.95 });
         result.Add(new Product { ProductId = 4, ProductName = "Framework", Price = 4999.95 });

         return result;
      }
   }

   #endregion
}
