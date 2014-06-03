using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   /// <summary>
   /// Use LINQ to query an in-memory collection
   /// </summary>
   public class Sample20 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         ProductCollection allProducts = ProductHelper.GetProductList();

         IEnumerable<Product> subset =
            from p in allProducts
            where p.ProductColor.Substring(0, 1) == "W"
            select p;

         foreach (Product item in subset)
         {
            Debug.WriteLine(item.ProductColor);
         }
      }
   }
}
