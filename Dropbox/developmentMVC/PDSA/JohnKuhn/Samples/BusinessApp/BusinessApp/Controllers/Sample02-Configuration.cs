using System.Web.Mvc;
using BusinessApp.Utilities;

namespace BusinessApp.Controllers
{
   /// <summary>
   /// Sample 02 - Configuration - Controller
   /// </summary>
   public class Sample02Controller : WebController
   {
      /// <summary>
      /// Demonstrates using a common configuration class
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      public ActionResult Index()
      {
         ViewBag.ConnectionString = BusinessApp.Configuration.Settings.ConnectionString;

         return View();
      }
   }
}