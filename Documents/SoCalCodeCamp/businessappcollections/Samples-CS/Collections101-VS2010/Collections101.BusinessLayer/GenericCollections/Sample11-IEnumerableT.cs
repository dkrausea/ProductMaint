using System.Collections.Generic;
using Collections101.BusinessLayer.Entities;
using System.Collections;
using System.Diagnostics;
using System;

namespace Collections101.BusinessLayer
{
   #region Basic IEnumerable<T>

   public class GenericEnumerable : IEnumerable<Product>
   {
      private Product[] _list;

      #region Constructor

      public GenericEnumerable()
      {
         _list = new Product[0];
      }

      #endregion

      #region Add Method

      /// <summary>
      /// Add an item to the list
      /// </summary>
      /// <param name="item"></param>
      public void Add(Product item)
      {
         Product[] target = new Product[_list.Length + 1];
         Array.Copy(_list, target, _list.Length);
         target[target.Length - 1] = item;
         _list = target;
      }

      #endregion

      #region Indexer

      /// <summary>
      /// Get the current item in the list
      /// </summary>
      /// <param name="index"></param>
      /// <returns></returns>
      public Product this[int index]
      {
         get
         {
            return _list[index];
         }

         set
         {
            _list[index] = value;
         }
      }

      #endregion

      #region Length Property

      /// <summary>
      /// Get the length of the list
      /// </summary>
      public int Length
      {
         get
         {
            return _list.Length;
         }
      }

      #endregion

      #region IEnumerable<Product> Members

      public IEnumerator<Product> GetEnumerator()
      {
         return new GenericEnumerator(this);
      }

      #endregion

      #region IEnumerable Members

      IEnumerator IEnumerable.GetEnumerator()
      {
         return new GenericEnumerator(this);
      }

      #endregion

      #region Generic Enumerator Example

      private class GenericEnumerator : IEnumerator<Product>
      {
         private int _index = -1;
         private GenericEnumerable _list = null;

         #region Constructor

         public GenericEnumerator(GenericEnumerable list)
         {
            _list = list;
         }

         #endregion

         #region IEnumerator<Product> Members

         public Product Current
         {
            get { return _list[_index]; }
         }

         #endregion

         #region IDisposable Members

         public void Dispose()
         {
            // Nothing to do -- 
         }

         #endregion

         #region IEnumerator Members

         object IEnumerator.Current
         {
            get { return _list[_index]; }
         }

         /// <summary>
         /// Move to the next item in the list
         /// </summary>
         /// <returns></returns>
         public bool MoveNext()
         {
            bool result = false;
            if (_index < _list.Length - 1)
            {
               _index++;
               result = true;
            }
            return result;
         }

         /// <summary>
         /// Reset the position in the list
         /// </summary>
         public void Reset()
         {
            _index = -1;
         }

         #endregion
      }

      #endregion
   }

   #endregion


   /// <summary>
   /// Demonstrates an implementation of 
   /// the generic IEnumerable interface
   /// </summary>
   public class Sample11 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         GenericEnumerable collection = new GenericEnumerable();

         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(2, "White"));
         collection.Add(new Product(3, "Blue"));

         // Get an enumerator for this collection
         IEnumerator<Product> enumerator = collection.GetEnumerator();

         // Use the enumerator to move through the list
         while (enumerator.MoveNext())
         {
            Debug.WriteLine(enumerator.Current.ProductColor);
         }
      }
   }
}
