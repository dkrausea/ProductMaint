using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BusinessApp.Configuration
{
   public class Settings
   {
      public static string ConnectionString
      {
         get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
      }
   }
}
