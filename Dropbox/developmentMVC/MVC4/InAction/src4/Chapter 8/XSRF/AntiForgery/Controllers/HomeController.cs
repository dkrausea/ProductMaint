using System.Web.Mvc;

namespace AntiForgery.Controllers
{
    using AntiForgery.Models;

    [HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[ValidateAntiForgeryToken]
		public ViewResult Save(InputModel form)
		{
			return View(form);
		}
	}
}