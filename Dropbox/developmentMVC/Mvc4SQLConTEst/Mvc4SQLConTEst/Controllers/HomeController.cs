using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.DAL;
using MvcChipRequest.Models;

namespace MvcChipRequest.Controllers
{
   public class HomeController : Controller
   {
      private RequestContext db = new RequestContext();

      public ActionResult Index()
      {
         var chiprequests = db.ChipRequests;
         return View(chiprequests.ToList());
      }

      public ActionResult CreateDemand(int id)
      {
         return View();
      }

      public ActionResult About()
      {
         ViewBag.Message = "Your app description page.";

         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Your contact page.";

         return View();
      }
   }
}
