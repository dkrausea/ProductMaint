using System;
using System.Diagnostics;
using System.Web.Mvc;
using BusinessApp.Framework.Logging;
using BusinessApp.Utilities;

namespace BusinessApp.Controllers
{
   /// <summary>
   /// Sample 06 - Logging - Controller class
   /// </summary>
   public class Sample06Controller : WebController
   {
      #region Logging Provider Instance

      private LoggingProvider _logger;

      public LoggingProvider Logger
      {
         get
         {
            if (_logger == null)
            {
               _logger = new LoggingProvider();
            }
            return _logger;
         }
      }

      #endregion
      
      /// <summary>
      /// Get the Index view
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      public ActionResult Index()
      {
         // There are lots of reasons to have logging.

         // User tracking, custom events, exceptions, etc.
         this.Logger.Log("Sample06Controller", "UserVisit");

         return View();
      } 
   }
}
