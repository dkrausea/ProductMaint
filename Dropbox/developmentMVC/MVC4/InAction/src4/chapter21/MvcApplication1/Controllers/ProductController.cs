using System.Collections.Generic;
using System.Web.Mvc;
using HostingSample.Models;

namespace HostingSample.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository
            = new ProductRepository();

        public ActionResult List()
        {
            IEnumerable<Product> products = _productRepository.GetAllProducts();
            return View(products);
        }

        public ActionResult Show(int id)
        {
            Product product = _productRepository.GetById(id);
            return View(product);
        }
    }
}