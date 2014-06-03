using System;
using System.Collections;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Basic DictionaryBase

   public class BasicDictionaryBase : DictionaryBase
   {
      #region Indexer

      public Product this[string key]
      {
         get
         {
            return (Product)this.Dictionary[key];
         }
         set
         {
            this.Dictionary[key] = value;
         }
      }

      #endregion

      #region Keys

      public ICollection Keys
      {
         get
         {
            return this.Dictionary.Keys;
         }
      }
      
      #endregion

      #region Values

      public ICollection Values
      {
         get
         {
            return this.Dictionary.Values;
         }
      }

      #endregion

      #region Add

      public void Add(string key, Product value)
      {
         this.Dictionary.Add(key, value);
      }

      #endregion

      #region Contains

      public bool Contains(string key)
      {
         return this.Dictionary.Contains(key);
      }

      #endregion

      #region Remove

      public void Remove(string key)
      {
         this.Dictionary.Remove(key);
      }

      #endregion
   }

   #endregion

   /// <summary>
   /// Demonstrates a strongly-typed collection of key/value pairs
   /// of business objects based on DictionaryBase
   /// </summary>
   public class Sample09 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicDictionaryBase dictionary = new BasicDictionaryBase();
         
         dictionary.Add("Red", new Product(1, "Red"));
         dictionary.Add("White", new Product(2, "White"));
         dictionary.Add("Blue", new Product(3, "Blue"));

         if (dictionary.Contains("White"))
         {
            Debug.WriteLine(dictionary["White"].ProductColor);
         }

         try
         {
            dictionary.Add("White", new Product(4, "Silver"));
         }
         catch (Exception ex)
         {
            Debug.WriteLine(ex);
         }
      }
   }
}
