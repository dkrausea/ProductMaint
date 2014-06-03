using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   /// <summary>
   /// Use an expression lambda to provide sort criteria
   /// and then use a statement lamda to display the results.
   /// </summary>
   public class Sample19 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         ProductCollection collection = new ProductCollection();

         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(2, "White"));
         collection.Add(new Product(3, "Blue"));

         collection.Sort(
            (x, y) => x.ProductColor.CompareTo(y.ProductColor));

         collection.ForEach(p => { Debug.WriteLine(p.ProductColor); });
      }
   }
}
