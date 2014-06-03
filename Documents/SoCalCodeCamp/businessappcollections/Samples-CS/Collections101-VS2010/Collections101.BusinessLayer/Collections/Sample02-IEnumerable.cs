using System;
using System.Diagnostics;
using System.Collections;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Basic IEnumerable Example

   /// <summary>
   /// Custom class which implements IEnumerable
   /// so that clients may invoke the GetEnumerator() method
   /// </summary>
   public class BasicEnumerable : IEnumerable
   {
      // Private object arry
      private object[] _list;

      #region Constructor

      /// <summary>
      /// Initialize the array
      /// </summary>
      public BasicEnumerable()
      {
         _list = new object[0];
      }

      #endregion

      #region Indexer

      /// <summary>
      /// Get the current item in the list
      /// </summary>
      /// <param name="index"></param>
      /// <returns></returns>
      public object this[int index] 
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

      #region IEnumerable Members

      /// <summary>
      /// Implementation of IEnumerable interface
      /// </summary>
      /// <returns>Instance of IEnumerator</returns>
      public IEnumerator GetEnumerator()
      {
         return new BasicEnumerator(this);
      }

      #endregion

      #region Add Method

      /// <summary>
      /// Add an item to the list
      /// </summary>
      /// <param name="item"></param>
      public void Add(object item)
      {
         object[] target = new object[_list.Length + 1];
         Array.Copy(_list, target, _list.Length);
         target[target.Length - 1] = item;
         _list = target;
      }

      #endregion

      #region Basic IEnumerator Example

      /// <summary>
      /// Custom class which implements IEnumerator to move through
      /// the items in an instance of the BasicEnumerable class
      /// </summary>
      private class BasicEnumerator : IEnumerator
      {
         private int _index = -1;
         private BasicEnumerable _list = null;

         #region Constructor

         public BasicEnumerator(BasicEnumerable list)
         {
            _list = list;
            _index = -1;
         }

         #endregion

         #region IEnumerator Members

         /// <summary>
         /// Return the current item in the list
         /// </summary>
         public object Current
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
   /// Demonstrates an implementation of IEnumerable
   /// </summary>
   public class Sample02 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicEnumerable collection = new BasicEnumerable();

         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(2, "White"));
         collection.Add(new Product(3, "Blue"));

         // Get an enumerator for this collection
         IEnumerator enumerator = collection.GetEnumerator();

         // Use the enumerator to move through the list
         while (enumerator.MoveNext())
         {
            Product item = (Product)enumerator.Current;
            Debug.WriteLine(item.ProductColor);
         }

         foreach (var item in collection)
         {
            Product prod = (Product)item;
            // prod.ProductColor;
         }
      }
   }
}
