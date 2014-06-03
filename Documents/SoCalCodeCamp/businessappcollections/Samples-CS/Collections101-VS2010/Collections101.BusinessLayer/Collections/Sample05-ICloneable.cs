using System;
using System.Diagnostics;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{
   #region Cloneable Object

   public class BasicCloneable : ICloneable
   {
      public string Value { get; set; }

      #region ICloneable Members

      public object Clone()
      {
         return this.MemberwiseClone();
      }

      #endregion
   }

   #endregion

   /// <summary>
   /// Demonstrates an implementation of ICloneable
   /// </summary>
   /// <remarks>
   /// Object variables are just pointers; you must implement ICloneable to provide  
   /// a means for clients of your object to make copies that are not references 
   /// to the same instance.
   /// </remarks>
   public class Sample05 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         BasicCloneable item = new BasicCloneable();
         item.Value = "Red";

         BasicCloneable notCloned = item;
         notCloned.Value = "White";

         Debug.WriteLine(item.Value);
         Debug.WriteLine(notCloned.Value);

         BasicCloneable clone = (BasicCloneable)item.Clone();
         clone.Value = "Blue";

         Debug.WriteLine(item.Value);
         Debug.WriteLine(clone.Value);
      }
   }
}
