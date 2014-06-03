using System;
using System.Diagnostics;
using System.Web.Mvc;
using BusinessApp.Utilities;

namespace BusinessApp.Controllers
{
   /// <summary>
   /// Sample 05 - Session Management - Controller class
   /// </summary>
   public class Sample04Controller : WebController
   {     
      /// <summary>
      /// Present the Index view with data from state
      /// </summary>
      /// <returns>An ActionResult instance</returns>
      public ActionResult Index()
      {
         Debugger.Break();

         // Store a value in ViewBag
         this.ViewBag.SomeDate = new DateTime(2004, 9, 13);
         this.ViewBag.JohnKuhn = "John A. Kuhn";

         // Store a value in TempData
         this.TempData["CompanyName"] = "PDSA, Inc.";

         // Store a value in custom session object
         this.UserSession.Today = DateTime.Now;

         return View();
      }

      /// <summary>
      /// Handles post from the Index view
      /// </summary>
      /// <param name="values">form values</param>
      /// <returns>An ActionResult instance</returns>
      [HttpPost]
      public ActionResult Index(FormCollection values)
      {
         Debugger.Break();

         DateTime value = this.ViewBag.SomeDate ?? DateTime.Now;

         string customerName = this.TempData["CompanyName"].ToString();

         return View();
      }
   }
}
