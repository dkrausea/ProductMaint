using System.Collections;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Basic Collection using CollectionBase 

   /// <summary>
   /// A custom collection using the features of CollectionBase
   /// to provide better features with less code.
   /// </summary>
   public class BasicCollectionBase : CollectionBase 
   {
      public Product this[int index]
      {
         get
         {
            return (Product)this.List[index];
         }
         set
         {
            this.List[index] = value;
         }
      }

      public int Add(Product value)
      {
         // Access to the collection is through the List
         // property, which is an instance of IList

         return this.List.Add(value);

         // It is also possible to directly access the InnerList,
         // an ArrayList that is the storage for elements in the 
         // collection

         // return this.InnerList.Add(value);
      }

      public int IndexOf(Product value)
      {
         return this.List.IndexOf(value);
      }

      public void Insert(int index, Product value)
      {
         this.List.Insert(index, value);
      }

      public void Remove(Product value)
      {
         this.List.Remove(value);
      }

      public bool Contains(Product value)
      {
         return this.List.Contains(value);
      }
   }

   #endregion

   /// <summary>
   /// Demonstrates using CollectionBase to create 
   /// a strongly-typed collection
   /// </summary>
   public class Sample08 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicCollectionBase collection = new BasicCollectionBase();

         // Since the methods are strongly-typed, it prevents us 
         // from adding anything to the collection that is not the 
         // correct type...
         // collection.Add("Silver");

         collection.Add(new Product(1, "Red"));
         collection.Add(new Product(2, "White"));
         collection.Add(new Product(3, "Blue"));

         // Now, we can simply iterate over products
         foreach (Product item in collection)
         {
            Debug.WriteLine(item.ProductColor);
         }
      }
   }
}
