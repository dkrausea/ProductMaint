using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerFactoryExamples.Models;

namespace ControllerFactoryExamples.Controllers
{
    public class HomeController : Controller
    {
        private IMessageProvider _messageProvider;

        public HomeController(IMessageProvider messageProvider)
        {
            _messageProvider = messageProvider;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _messageProvider.GetMessage();

            return View();
        }
    }
}
