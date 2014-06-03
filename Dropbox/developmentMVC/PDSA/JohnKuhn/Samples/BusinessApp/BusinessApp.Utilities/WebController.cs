using System.Web.Mvc;

namespace BusinessApp.Utilities
{
   /// <summary>
   /// Base class for all custom app controllers
   /// </summary>
   public class WebController : Controller
   {
      private WebUserSession _session;
      
      public WebUserSession UserSession
      {
         get
         {
            if (_session == null)
               _session = new WebUserSession();
            return _session;
         }
         set
         {
            _session = value;
         }
      }
   }
}
