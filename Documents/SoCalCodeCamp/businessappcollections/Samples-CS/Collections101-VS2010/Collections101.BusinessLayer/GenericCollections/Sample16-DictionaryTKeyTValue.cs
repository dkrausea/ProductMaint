using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Strongly-typed dictionary inherits generic dictionary

   public class ProductDictionary : Dictionary<string, Product>
   {
      // Also no further implementation required!
   }

   #endregion

   class Sample16 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         ProductDictionary dictionary = new ProductDictionary();

         dictionary.Add("key1", new Product(1, "Red"));
         dictionary.Add("key2", new Product(1, "White"));
         dictionary.Add("key3", new Product(1, "Blue"));

         foreach (string key in dictionary.Keys)
         {
            Product item = dictionary[key];
         }

         foreach (KeyValuePair<string, Product> item in dictionary)
         {
            Debug.WriteLine(item.Value.ProductColor);
         }
      }
   }
}
