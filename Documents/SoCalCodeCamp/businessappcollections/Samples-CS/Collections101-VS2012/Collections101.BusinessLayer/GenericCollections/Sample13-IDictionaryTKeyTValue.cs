using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   public class Sample13 : ISample
   {
      #region Basic Dictionary<TKey, TValue>

      public class GenericDictionary : IDictionary<string, Product>
      {
         private int _index = -1;
         private KeyValuePair<string, Product>[] _list;

         #region Constructor

         public GenericDictionary()
         {
            _list = new KeyValuePair<string, Product>[0];
         }

         #endregion

         #region IDictionary<string,Product> Members

         public void Add(string key, Product value)
         {
            this.Add(new KeyValuePair<string, Product>(key, value));
         }

         public bool ContainsKey(string key)
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

         public ICollection<string> Keys
         {
            get 
            {
               ICollection<string> result;

               result = new List<string>();
               for (int i = 0; i < _list.Length - 1; i++)
               {
                  result.Add(_list[i].Key);
               }

               return result;
            }
         }

         public bool Remove(string key)
         {
            bool result = false;

            if (this.ContainsKey(key))
            {
               KeyValuePair<string, Product>[] target = new KeyValuePair<string, Product>[_list.Length - 1];
               Array.Copy(_list, _index + 1, target, _index, _list.Length - (_index + 1));
               if (_index > 0) Array.Copy(_list, 0, target, 0, _index);
               _list = target;
               _index = -1;
               result = true;
            }

            return result;
         }

         public bool TryGetValue(string key, out Product value)
         {
            bool result = false;

            if (this.ContainsKey(key))
            {
               value = _list[0].Value;
            }
            else
            {
               value = null;
            }

            return result;
         }

         public ICollection<Product> Values
         {
            get 
            {
               ICollection<Product> result;

               result = new List<Product>();
               for (int i = 0; i < _list.Length - 1; i++)
               {
                  result.Add(_list[i].Value);
               }

               return result;
            }
         }

         public Product this[int index]
         {
            get
            {
               return _list[index].Value;
            }
            set
            {
               string key = _list[index].Key;
               if (this.Remove(key))
               {
                  this.Add(new KeyValuePair<string, Product>(key, value));
               }
            }
         }

         public Product this[string key]
         {
            get
            {
               Product result;
               if (!this.TryGetValue(key, out result))
               {
                  // throw an exception -- key does not exist
               }
               return result;
            }
            set
            {
               if (this.ContainsKey(key))
               {
                  if (this.Remove(key))
                  {
                     this.Add(new KeyValuePair<string,Product>(key, value));
                  }
               }
            }
         }

         #endregion

         #region ICollection<KeyValuePair<string,Product>> Members

         public void Add(KeyValuePair<string, Product> item)
         {
            if (!this.Contains(item))
            {
               KeyValuePair<string, Product>[] target = new KeyValuePair<string, Product>[_list.Length + 1];
               Array.Copy(_list, target, _list.Length);
               target[target.Length - 1] = item;
               _list = target;
            }
            else
            {
               throw new InvalidOperationException(string.Format("Key '{0}' already exists.", item.Key));
            }
         }

         public void Clear()
         {
            _list = new KeyValuePair<string,Product>[0];
         }

         public bool Contains(KeyValuePair<string, Product> item)
         {
            bool result = false;

            for (int i = 0; i < _list.Length; i++)
            {
               if (_list[i].Equals(item))
               {
                  result = true;
                  _index = i;
                  break;
               }
            }

            return result;
         }

         public void CopyTo(KeyValuePair<string, Product>[] array, int arrayIndex)
         {
            Array.Copy(_list, arrayIndex, array, 0, _list.Length - arrayIndex);
         }

         public int Count
         {
            get { return _list.Length; }
         }

         public bool IsReadOnly
         {
            get { return false; }
         }

         public bool Remove(KeyValuePair<string, Product> item)
         {
            bool result = false;

            if (this.Contains(item))
            {
               KeyValuePair<string, Product>[] target = new KeyValuePair<string, Product>[_list.Length - 1];
               Array.Copy(_list, _index + 1, target, _index, _list.Length - (_index + 1));
               if (_index > 0) Array.Copy(_list, 0, target, 0, _index);
               _list = target;
               _index = -1;
               result = true;
            }

            return result;            
         }

         #endregion

         #region IEnumerable<KeyValuePair<string,Product>> Members

         public IEnumerator<KeyValuePair<string, Product>> GetEnumerator()
         {
            return new GenericEnumerator(_list);
         }

         #endregion

         #region IEnumerable Members

         IEnumerator IEnumerable.GetEnumerator()
         {
            return new GenericEnumerator(_list);
         }

         #endregion

         #region Generic Enumerator Example

         private class GenericEnumerator : IEnumerator<KeyValuePair<string, Product>>
         {
            private int _index = -1;
            private KeyValuePair<string, Product>[] _list = null;

            #region Constructor

            public GenericEnumerator(KeyValuePair<string, Product>[] list)
            {
               _list = list;
            }

            #endregion

            #region IEnumerator<Product> Members

            KeyValuePair<string, Product> IEnumerator<KeyValuePair<string, Product>>.Current
            {
               get 
               {
                  return _list[_index];
               }
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

      public void RunDemo()
      {
         Debugger.Break();

         GenericDictionary dictionary = new GenericDictionary();
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
