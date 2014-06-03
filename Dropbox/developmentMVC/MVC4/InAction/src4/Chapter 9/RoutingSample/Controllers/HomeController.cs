using System.Web.Mvc;

namespace RoutingSample.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Privacy() 
		{
			return View();
		}
	}
}