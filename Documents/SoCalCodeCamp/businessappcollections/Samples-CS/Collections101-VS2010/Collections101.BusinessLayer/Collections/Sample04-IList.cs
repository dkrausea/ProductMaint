using System;
using System.Collections;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Basic List

   /// <summary>
   /// Custom class implement IList, a more complete
   /// representation of collection features
   /// </summary>
   public class BasicList : IList
   {
      private object[] _list;

      #region Constructor

      public BasicList()
      {
         _list = new object[0];
      }

      #endregion

      #region IList Members

      public int Add(object value)
      {
         int result = -1;
         object[] target = new object[_list.Length + 1];
         Array.Copy(_list, target, _list.Length);
         result = target.Length - 1;
         target[result] = value;
         _list = target;
         return result;
      }

      public void Clear()
      {
         _list = new object[0];
      }

      public bool Contains(object value)
      {
         bool result = false;
         foreach (object item in _list)
         {
            if (item.Equals(value))
            {
               result = true;
               break;
            }
         }
         return result;
      }

      public int IndexOf(object value)
      {
         int result = -1;
         for (int i = 0; i < _list.Length; i++)
         {
            if (_list[i].Equals(value))
            {
               result = i;
               break;
            }            
         }
         return result;
      }

      public void Insert(int index, object value)
      {
         object[] target = new object[_list.Length + 1];
         
         Array.Copy(_list, index, target, index + 1, _list.Length - index);
         target[index] = value;
         if (index > 0) Array.Copy(_list, 0, target, 0, index);

         _list = target;
      }

      public bool IsFixedSize
      {
         get { return false; }
      }

      public bool IsReadOnly
      {
         get { return false; }
      }

      public void Remove(object value)
      {
         int index = this.IndexOf(value);
         this.RemoveAt(index);
      }

      public void RemoveAt(int index)
      {
         if (index >= 0)
         {
            object[] target = new object[_list.Length - 1];
            Array.Copy(_list, index + 1, target, index, _list.Length - (index + 1));
            if (index > 0) Array.Copy(_list, 0, target, 0, index);
            _list = target;
         }
      }

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

      public void CopyTo(Array array, int index)
      {
         Array.Copy(_list, index, array, 0, _list.Length - index);
      }

      public int Count
      {
         get { return _list.Length; }
      }

      public bool IsSynchronized
      {
         get { return false; }
      }

      public object SyncRoot
      {
         get { return null; }
      }

      #endregion

      #region IEnumerable Members

      public IEnumerator GetEnumerator()
      {
         return new BasicListEnumerator(this);
      }

      #endregion

      #region Basic List Enumerator

      private class BasicListEnumerator : IEnumerator
      {
         private int _index = -1;
         private BasicList _list;

         #region Constructor

         public BasicListEnumerator(BasicList list)
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
   /// Demonstrates an implementation of IList
   /// </summary>
   public class Sample04 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicList collection = new BasicList();
         object test = new Product(4, "Silver");

         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(2, "White"));
         collection.Add(new Product(3, "Blue"));

         // Access an item using the indexer
         object item = collection[2];

         // Insert another item at position 2
         collection.Insert(2, test);

         // Find out if the collection contains an item
         if (collection.Contains(test))
         {
            // Remove an item
            collection.Remove(test);
         }
      }
   }
}
