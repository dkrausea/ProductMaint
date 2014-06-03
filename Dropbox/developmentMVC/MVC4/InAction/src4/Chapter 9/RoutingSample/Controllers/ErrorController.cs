using System.Web.Mvc;

namespace RoutingSample.Controllers
{
	public class ErrorController : Controller
	{
		public ActionResult NotFound()
		{
			return new NotFoundResult();
		}
	}
}