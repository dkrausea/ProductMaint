using System.Diagnostics;
using System.Web.Mvc;

namespace BusinessApp.Controllers
{
   /// <summary>
   /// Sample 01 - Security - Controller class
   /// </summary>
   public class Sample01Controller : Controller
   {
      /// <summary>
      /// Requests to URL /Sample01 are secured in the web.config file
      /// by the location element with an authorization element configured
      /// to deny un-authenticated users.  By convention, the default is 'Index'.
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      public ActionResult Index()
      {
         return View();
      }

      /// <summary>
      /// Requests to /Sample01/SecuredByAttribute are secured by the 
      /// AuthorizeAttribute declared on this controller method.  
      /// </summary>
      /// <remarks>
      /// Requests by users who are not in the named role will 
      /// automatically re-direct to the login page.
      /// </remarks>
      /// <returns>An ActionResult instance</returns>
      [Authorize(Roles = "Administrator")]
      public ActionResult SecuredByAttribute()
      {
         return View();
      }

      /// <summary>
      /// Requests to /Sample01/SecuredByContext uses the current HttpContext 
      /// to determine whether the user has permission to the view, otherwise
      /// re-directs to the AccessDenied action.
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      public ActionResult SecuredByContext()
      {
         Debugger.Break();

         ActionResult result = null;

         if (this.HttpContext.User.IsInRole("Administrator"))
         {
            result = View();
         }
         else
         {
            result = RedirectToAction("AccessDenied");
         }

         return result;
      }

      /// <summary>
      /// Displays the Access Denied view page.
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      public ActionResult AccessDenied()
      {
         Debugger.Break();

         return View();
      }
   }
}
