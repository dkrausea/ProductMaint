using System.Web.Mvc;

namespace Mvc4Roles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "developers")]
        public ActionResult Developers()
        {
            return View();
        }

        [Authorize(Users = "admin")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}
