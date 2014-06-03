using System;
using System.Diagnostics;
using System.Web.Mvc;
using BusinessApp.Framework.Exceptions;

namespace BusinessApp.Controllers
{
   /// <summary>
   /// Sample custom exception
   /// </summary>
   public class Sample05Exception : Exception
   {
      public Sample05Exception(string message) : base(message) { }
   }

   /// <summary>
   /// Sample 05 - Exception Handling - Controller class
   /// </summary>
   public class Sample05Controller : Controller
   {
      /// <summary>
      /// Get the Index view
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      public ActionResult Index()
      {
         return View();
      }

      /// <summary>
      /// Unhandled exception goes to the global error view
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      /// s<remarks>
      /// The customErrors element mode attribute must be set to "On"
      /// </remarks>
      public ActionResult UnhandledException()
      {
         Debugger.Break();

         throw new Sample05Exception("Unhandled exception!");
      }

      /// <summary>
      /// Handle an error using the HandleError attribute
      /// </summary>
      /// <remarks>
      /// The customErrors element mode attribute must be set to "On"
      /// </remarks>
      /// <returns>An ActionResult instance</returns>
      [HandleError(View = "CustomError")]
      public ActionResult HandledByAttribute()
      {
         Debugger.Break();

         throw new Sample05Exception("Unhandled exception!");
      }

      /// <summary>
      /// Handle a post request from the Index view 
      /// </summary>
      /// <param name="values">FormCollection of form values</param>
      /// <returns>An ActionResult instance</returns>
      [HttpPost]
      public ActionResult Index(FormCollection values)
      {
         Debugger.Break();

         try
         {
            throw new Sample05Exception("Unhandled exception!");
         }
         catch (Exception ex)
         {
            // Use a logger and/or publisher to track the 
            // occurrence of the error
            ExceptionHandler handler = new ExceptionHandler();
            handler.Publish(ex);

            // Put something into the model state collection to 
            // inform the user what happened.
            this.ModelState.AddModelError(string.Empty, ex.Message);   
         }

         return View();
      }

      public ActionResult CustomError()
      {
         return View();
      }
   }
}
