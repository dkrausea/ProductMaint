using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.BusinessLayer.LookupTables
{
   public class KeyValuePair
   {
      public string Key { get; set; }
      public static string KeySchema { get { return "Key"; } }
      public string Value { get; set; }
      public static string ValueSchema { get { return "Value"; } }
   }
}
