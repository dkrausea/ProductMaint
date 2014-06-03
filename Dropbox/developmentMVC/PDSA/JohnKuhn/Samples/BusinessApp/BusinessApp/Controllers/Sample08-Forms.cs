using System.Web.Mvc;
using BusinessApp.Utilities;
using BusinessApp.ViewModels;

namespace BusinessApp.Controllers
{
   public class Sample08Controller : WebController
   {
      public ActionResult Index()
      {
         CustomerDetailsViewModel vm = new CustomerDetailsViewModel();

         return View(vm);
      }

      [HttpPost]
      public ActionResult Index(CustomerDetailsViewModel viewModel)
      {
         ActionResult result;

         result = View(viewModel);

         return result;
      }
   }
}
