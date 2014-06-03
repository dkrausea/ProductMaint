using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   /// <summary>
   /// Use an extension method and statement lambda 
   /// to filter items in a collection.
   /// </summary>
   public class Sample18 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         ProductCollection products = ProductHelper.GetProductList();

         // Use an expression with the Where() extension method to get an
         // IEnumerable<Product>

         //var subset =
         //   products.Where(p => p.ProductColor.Substring(0, 1) == "W");


         var subset =
            products.Where(p => p.ProductColor.Substring(0, 1) == "W");

         

         // Since the result is an IEnumerable<Product>, we can 
         // iterate over the items in the result set.
         foreach (Product item in subset)
         {
            Debug.WriteLine(item.ProductColor); 
         }

         // Turn the result into a List<Product>
         List<Product> list = subset.ToList<Product>();

         // List<T> has an extension method of ForEach() to allow 
         // iterating over the elements in the list.

         // Use a statement lambda to display each 
         // product color in the result set

         //list.ForEach(
         //   p => 
         //      { 
         //         Debug.WriteLine(p.ProductColor);                
         //      });

         list.ForEach(p => { Debug.WriteLine(p.ProductColor); });

      }
    }
}
