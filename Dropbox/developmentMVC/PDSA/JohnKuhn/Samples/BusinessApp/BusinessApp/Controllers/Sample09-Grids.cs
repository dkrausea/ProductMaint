using System.Web.Mvc;
using BusinessApp.Utilities;
using BusinessApp.ViewModels;

namespace BusinessApp.Controllers
{
   public class Sample09Controller : WebController
   {
      public ActionResult Index()
      {
         CustomerIndexViewModel viewModel = new CustomerIndexViewModel();
         viewModel.LoadAll();
         return View(viewModel);
      }
   }
}