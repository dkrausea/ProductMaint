using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Strongly-typed collection inherits generic List

   public class ProductCollection : List<Product>
   {
      // No further implementation required!

      public decimal GetSumOfAllProducts()
      {
         decimal result = 0;

         foreach (var item in this)
         {
            
         }

         return result;
      }
   }

   #endregion

   public class Sample15 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         ProductCollection collection = new ProductCollection();

         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(2, "White"));
         collection.Add(new Product(3, "Blue"));

         foreach (Product item in collection)
         {
            Debug.WriteLine(item.ProductColor);
         }
      }
   }
}
