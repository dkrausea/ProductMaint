using System;
using System.Collections;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Basic Collection Class

   public class BasicCollection : ICollection
   {
      // Private array of objects
      private object[] _list;

      #region Constructor

      /// <summary>
      /// Initialize the list
      /// </summary>
      public BasicCollection()
      {
         _list = new object[0];
      }

      #endregion

      #region Indexer

      /// <summary>
      /// Get an item from the list at position N
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

      #region ICollection Members

      /// <summary>
      /// Implementation of ICollection CopyTo method
      /// </summary>
      /// <param name="array"></param>
      /// <param name="index"></param>
      public void CopyTo(Array array, int index)
      {
         Array.Copy(_list, index, array, 0, _list.Length - index);
      }

      /// <summary>
      /// Gets the number of items in the list
      /// </summary>
      public int Count
      {
         get { return _list.Length; }
      }

      /// <summary>
      /// Lets clients know whether this collection is thread safe
      /// </summary>
      public bool IsSynchronized
      {
         get { return false; }
      }

      /// <summary>
      /// Lets clients lock this list for thread safe operations
      /// </summary>
      public object SyncRoot
      {
         get { return null; }
      }

      #endregion

      #region IEnumerable Members

      /// <summary>
      /// Implements IEnumerable GetEnumerator() method
      /// </summary>
      /// <returns>An instance of an IEnumerator</returns>
      public IEnumerator GetEnumerator()
      {
         return new BasicCollectionEnumerator(this);
      }

      #endregion

      #region Add Method

      /// <summary>
      /// Still need a method to add a new item 
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

      #region Basic Collection Enumerator

      private class BasicCollectionEnumerator : IEnumerator
      {
         private int _index = -1;
         private BasicCollection _list;

         #region Constructor

         public BasicCollectionEnumerator(BasicCollection list)
         {
            _list = list;
         }

         #endregion

         #region IEnumerator Members

         public object Current
         {
            get { return _list[_index]; }
         }

         public bool MoveNext()
         {
            bool result = false;
            if (_index < _list.Count - 1)
            {
               _index++;
               result = true;
            }
            return result;
         }

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
   /// Demonstrates an implementation of ICollection
   /// </summary>
   public class Sample03 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicCollection collection = new BasicCollection();

         // Add some items to the collection
         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(1, "White"));
         collection.Add(new Product(1, "Blue"));

         // Using foreach does not require you to
         // call GetEnumerator() and MoveNext()
         foreach (object item in collection)
         {
            Debug.WriteLine(item);
         }

         // Copy the values to an array using the CopyTo method
         object[] values = new object[collection.Count];
         collection.CopyTo(values, 0);

         foreach (object item in values)
         {
            Debug.WriteLine(item);
         }
      }
   }
}
