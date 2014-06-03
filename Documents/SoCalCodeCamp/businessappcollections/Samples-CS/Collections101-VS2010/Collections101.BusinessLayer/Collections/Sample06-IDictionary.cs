using System;
using System.Collections;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Basic Dictionary

   /// <summary>
   /// Implements the IDictionary interface
   /// </summary>
   public class BasicDictionary : IDictionary
   {
      private int _index = -1;
      private DictionaryEntry[] _list;

      #region Constructor

      public BasicDictionary()
      {
         _list = new DictionaryEntry[0];
      }

      #endregion

      #region IDictionary Members

      public void Add(object key, object value)
      {
         if (!this.Contains(key))
         {
            DictionaryEntry item = new DictionaryEntry(key, value);
            DictionaryEntry[] target = new DictionaryEntry[_list.Length + 1];
            Array.Copy(_list, target, _list.Length);
            target[target.Length - 1] = item;
            _list = target;
         }
         else
         {
            throw new InvalidOperationException(string.Format("Key '{0}' already exists.", key));
         }
      }

      public void Clear()
      {
         _list = new DictionaryEntry[0];
      }

      public bool Contains(object key)
      {
         bool result = false;
         for (int i = 0; i < _list.Length; i++)
         {
            if (_list[i].Key.Equals(key))
            {
               result = true;
               _index = i;
               break;
            }
         }
         return result;
      }

      public IDictionaryEnumerator GetEnumerator()
      {
         return new BasicDictionaryEnumerator(this);
      }

      public bool IsFixedSize
      {
         get { return false; }
      }

      public bool IsReadOnly
      {
         get { return false; }
      }

      public ICollection Keys
      {
         get 
         {
            object[] keys = new object[_list.Length];
            for (int i = 0; i < _list.Length; i++)
            {
               keys[i] = _list[i].Key;
            }
            return keys;
         }
      }

      public void Remove(object key)
      {
         if (this.Contains(key))
         {
            DictionaryEntry[] target = new DictionaryEntry[_list.Length - 1];
            Array.Copy(_list, _index + 1, target, _index, _list.Length - (_index + 1));
            if (_index > 0) Array.Copy(_list, 0, target, 0, _index);
            _list = target;
            _index = -1;
         }
      }

      public ICollection Values
      {
         get
         {
            object[] values = new object[_list.Length];
            for (int i = 0; i < _list.Length; i++)
            {
               values[i] = _list[i].Value;
            }
            return values;
         }
      }

      public object this[object key]
      {
         get
         {
            object result = null;
            for (int i = 0; i < _list.Length; i++)
            {
               if (_list[i].Key.Equals(key))
               {
                  result = _list[i].Value;
                  break;
               }
            }
            return result;
         }
         set
         {
            for (int i = 0; i < _list.Length; i++)
            {
               if (_list[i].Key.Equals(key))
               {
                  _list[i].Value = value;
                  break;
               }
            }
         }
      }

      public object this[int index]
      {
         get
         {
            return _list[index].Value;
         }
         set
         {
            _list[index].Value = value;
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

      IEnumerator IEnumerable.GetEnumerator()
      {
         return new BasicDictionaryEnumerator(this);
      }

      #endregion

      #region BasicDictionaryEnumerator

      private class BasicDictionaryEnumerator : IDictionaryEnumerator
      {
         private int _index = -1;
         private BasicDictionary _dictionary;

         #region Constructor

         public BasicDictionaryEnumerator(BasicDictionary dictionary)
         {
            _dictionary = dictionary;
         }

         #endregion

         #region IDictionaryEnumerator Members

         public DictionaryEntry Entry
         {
            get { return (DictionaryEntry)_dictionary[_index]; }
         }

         public object Key
         {
            get { return this.Entry.Key; }
         }

         public object Value
         {
            get { return this.Entry.Value; }
         }

         #endregion

         #region IEnumerator Members

         public object Current
         {
            get { return _dictionary[_index]; }
         }

         public bool MoveNext()
         {
            bool result = false;
            if (_index < _dictionary.Count - 1)
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
   /// Demonstrates an implementation of IDictionary
   /// </summary>
   public class Sample06 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicDictionary dictionary = new BasicDictionary();

         dictionary.Add(1, "Red");
         dictionary.Add(2, "White");
         dictionary.Add(3, "Blue");
         dictionary.Add(4, "Silver");

         if (dictionary.Contains(4))
         {
            dictionary.Remove(4);
         }

         foreach (object key in dictionary.Keys)
         {
            Debug.WriteLine(key);
            Debug.WriteLine(dictionary[key]);
         }

         foreach (object item in dictionary.Values)
         {
            Debug.WriteLine(item);
         }
      }
   }
}
