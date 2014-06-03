using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMailer_Example.Mailers;
using Mvc.Mailer;

namespace MvcMailer_Example.Controllers
{
    public class HomeController : Controller
    {
        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }

        private IReportMailer _reportMailer = new ReportMailer();
        public IReportMailer ReportMailer
        {
            get { return _reportMailer; }
            set { _reportMailer = value; }
        }

        public ActionResult SendWelcomeMessage()
        {
            UserMailer.Welcome().Send(); //Send() extention method: using Mvc.Mailer
            return RedirectToAction("Index");
        }

        public ActionResult SendReportProducer()
        {
            ReportMailer.ReportProducer().Send();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

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
