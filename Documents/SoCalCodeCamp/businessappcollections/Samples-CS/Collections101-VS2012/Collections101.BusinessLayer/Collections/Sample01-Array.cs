using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   /// <summary>
   /// Arrays are the basis for most collections.
   /// Demonstrates using an array to store instances 
   /// of a business object.
   /// </summary>
   public class Sample01 : ISample 
   {
      public void RunDemo()
      {
         Debugger.Break();

         object[] items = new object[3];

         items[0] = new Product(1, "Red");
         items[1] = new Product(2, "White");
         items[2] = new Product(3, "Blue");

         for (int i = 0; i < items.Length; i++)
         {
            Product item = (Product)items[i];
            Debug.WriteLine(item.ProductColor);
         }
      }
   }
}
