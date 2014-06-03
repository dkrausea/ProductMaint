using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   /// <summary>
   /// Demonstrates an implementation of 
   /// the generic ICollection interface
   /// </summary>
   public class Sample12 : ISample
   {
      #region Basic ICollection<T>

      /// <summary>
      /// Class implements Generic ICollection
      /// </summary>
      public class GenericCollection : ICollection<Product>
      {
         private Product[] _list;

         #region Constructor

         public GenericCollection()
         {
            _list = new Product[0];
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

         #region ICollection<Product> Members

         public void Add(Product item)
         {
            Product[] target = new Product[_list.Length + 1];
            Array.Copy(_list, target, _list.Length);
            target[target.Length - 1] = item;
            _list = target;
         }

         public void Clear()
         {
            _list = new Product[0];
         }

         public bool Contains(Product item)
         {
            bool result = false;
            foreach (Product product in _list)
            {
               if (product.Equals(item))
               {
                  result = true;
                  break;
               }
            }
            return result;
         }

         public void CopyTo(Product[] array, int arrayIndex)
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

         public bool Remove(Product item)
         {
            int index = -1;
            bool result = false;

            for (int i = 0; i < _list.Length; i++)
            {
               if (_list[i].Equals(item))
               {
                  index = i;
                  break;
               }
            }

            if (index >= 0)
            {
               Product[] target = new Product[_list.Length - 1];
               Array.Copy(_list, index + 1, target, index, _list.Length - (index + 1));
               if (index > 0) Array.Copy(_list, 0, target, 0, index);
               _list = target;
               result = true;
            }

            return result;
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
            private GenericCollection _list = null;

            #region Constructor

            public GenericEnumerator(GenericCollection list)
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
               if (_index < _list.Count - 1)
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

         GenericCollection collection = new GenericCollection();
         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(2, "White"));
         collection.Add(new Product(3, "Blue"));

         foreach (Product item in collection)
         {
            Debug.WriteLine(item.ProductColor);
         }
      }
   }
}
