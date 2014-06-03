using System.Collections;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   /// <summary>
   /// Demonstrates using ArrayList
   /// </summary>
   public class Sample07 : ISample
   {
      /// <summary>
      /// ArrayList is a the simplest generalized
      /// implementation of collection interfaces
      /// </summary>
      public void RunDemo()
      {
         Debugger.Break();

         ArrayList list = new ArrayList();

         list.Add(new Product(1, "Red"));
         list.Add(new Product(3, "Blue"));

         // Does not prevent you from making mistakes, though...
         list.Add("White");

         foreach (object item in list)
         {
            Product prod = (Product)item;
         }
      }
   }
}
