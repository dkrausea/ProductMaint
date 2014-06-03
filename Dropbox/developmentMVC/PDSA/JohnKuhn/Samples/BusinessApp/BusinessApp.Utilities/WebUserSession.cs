using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessApp.Utilities
{
   public class WebUserSession
   {
      public static WebUserSession Instance { get; set; }

      public DateTime Today
      {
         get
         {
            return Convert.ToDateTime(HttpContext.Current.Session["Today"]);
         }
         set
         {
            HttpContext.Current.Session["Today"] = value;
         }
      }

      public string CustomerDeletedMessage
      {
         get
         {
            return HttpContext.Current.Session["CustomerDeletedMessage"].ToString();
         }
         set
         {
            HttpContext.Current.Session["CustomerDeletedMessage"] = value;
         }
      }

      public string EntryDeletedMessage
      {
         get
         {
            string result = null;

            if (HttpContext.Current.Session["EntryDeletedMessage"] != null)
            {
               result = HttpContext.Current.Session["EntryDeletedMessage"].ToString();
            }

            return result;
         }
         set
         {
            HttpContext.Current.Session["EntryDeletedMessage"] = value;
         }
      }
   }
}
