using System.Web.Mvc;
using Roles;

namespace Mvc4Roles.Controllers
{
	[Authorize(Roles = DemoRoleProvider.AdminRole)]
	public class AdminController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}

		[Authorize(Roles = DemoRoleProvider.ReaderRole)]
		public ViewResult Reader()
		{
			return View();
		}
	}
}