using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Collections101.BusinessLayer.Entities;

namespace Collections101.BusinessLayer
{

   public static class AllMyExtensions
   {
      public static int GetInteger(this String str)
      {
         int result = -1;

         int.TryParse(str, out result);

         return result;
      }

      public static string GetString(this int i)
      {
         return i.ToString();
      }
   }   

   public class Sample17 : ISample
   {
      public void RunDemo()
      {
         Debugger.Break();

         int target;
         string value;
        
         value = "1000";
         target = value.GetInteger();

         Debug.WriteLine(target);
      }
   }
}
