using System.Web.Mvc;

namespace BusinessApp.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }
   }
}
