using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFFA_SURF.Models;

namespace MvcFFA_SURF.Controllers
{
    public class HomeController : Controller
    {
        private MvcFFA_SURFContext db = new MvcFFA_SURFContext();
        public ActionResult Index()
        {
            var chipRequestSummary = db.ChipRequests.Include(c => c.MCNumber);
            //var atpSummary = db.ATPs.Include(a => a.ATPID);
            return View(chipRequestSummary.ToList()); 
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
