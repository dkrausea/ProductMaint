using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapExercise.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         ViewBag.Message = "Welcome to Gun Record";

         return View();
      }

      public ActionResult About()
      {
         ViewBag.Message = "About Gun Record";

         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Gun Record Contact";

         return View();
      }
   }
}
