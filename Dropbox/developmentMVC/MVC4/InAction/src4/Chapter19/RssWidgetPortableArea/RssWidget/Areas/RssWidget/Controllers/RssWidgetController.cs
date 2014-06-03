using System;
using System.Web.Mvc;
using RssWidgetPortableArea.Services;

namespace RssWidgetPortableArea.Controllers
{
    public class RssWidgetController : Controller
    {
        public ActionResult Index(string RssUrl)
        {
           return View(new SyndicationService().GetFeed(RssUrl, 10));
        }
    }
}