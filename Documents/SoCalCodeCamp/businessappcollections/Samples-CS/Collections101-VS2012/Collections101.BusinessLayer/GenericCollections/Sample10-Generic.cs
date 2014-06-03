using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Basic Generic Class

   public class BasicGeneric<T>
   {
      private T _instance = default(T);

      public T Instance
      {
         get { return _instance; }
         set { _instance = value; }
      }
   }

   public interface IStringProperty
   {
      string Value { get; set; }
   }

   public class BasicGenericFactory
   {
      public static T CreateEntity<T>(string data)
         where T : IStringProperty, new()
      {
         T result = new T();

         result.Value = data;

         return result;
      }
   }

   public class ImplementStringProperty : IStringProperty
   {
      #region IStringProperty Members

      private string _value = string.Empty;

      public string Value
      {
         get
         {
            return _value;
         }
         set
         {
            _value = value;
         }
      }

      #endregion
   }

   #endregion

   /// <summary>
   /// Demonstrates basic principles of generic classes
   /// </summary>
   public class Sample10 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicGeneric<string> one = new BasicGeneric<string>();
         one.Instance = "Value";

         BasicGeneric<Product> two = new BasicGeneric<Product>();
         two.Instance = new Product(1, "Red");

         BasicGeneric<object> three = new BasicGeneric<object>();
         three.Instance = new object();
      }
   }
}


