using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BusinessApp.Framework.Exceptions;

namespace BusinessApp
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         WebApiConfig.Register(GlobalConfiguration.Configuration);
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
         AuthConfig.RegisterAuth(); // What?  No AuthTable.Auths?  :)
      }

      //protected void Application_Error()
      //{
      //   Debug.WriteLine(Server.GetLastError().Message);

      //   // Publish the exception
      //   ExceptionHandler handler = new ExceptionHandler();
      //   handler.Publish(Server.GetLastError());

      //   // Clear the error
      //   // Server.ClearError();

      //   // Optionally, navigate somewhere
      //   // HttpContext.Current.Response.Redirect("~/Sample05/CustomError");
      //}
   }
}