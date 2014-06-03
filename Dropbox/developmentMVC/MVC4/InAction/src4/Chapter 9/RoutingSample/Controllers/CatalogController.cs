using System.Web.Mvc;
using RoutingSample.Models;

namespace RoutingSample.Controllers
{
	[HandleError]
	public class CatalogController : Controller
	{
		private readonly ProductRepository _productRepository = new ProductRepository();

		public ActionResult Index()
		{
			var products = _productRepository.GetAllProducts();
			return View(products);
		}

		public ActionResult Show(string productCode)
		{
			var product = _productRepository.GetByCode(productCode);

			if (product == null)
			{
				return new NotFoundResult();
			}

			return View(product);
		}

		[HttpPost]
		public ActionResult Buy(string productCode)
		{
			return RedirectToAction("Index");
		}

		public ActionResult Basket()
		{
			return View();
		}

		public ActionResult CheckOut()
		{
			return View();
		}
	}
}