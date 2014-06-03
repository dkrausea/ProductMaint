using System;
using System.Web.Mvc;
using BusinessApp.Utilities;
using BusinessApp.ViewModels;

namespace TemplateProject.Controllers
{
   public class CustomerController : WebController
   {
      public ActionResult Index()
      {
         this.UserSession.Today = DateTime.Now;

         if (this.UserSession.CustomerDeletedMessage != null)
         {
            ViewBag.Message = this.UserSession.CustomerDeletedMessage;
            this.UserSession.CustomerDeletedMessage = null;
         }
         else
         {
            ViewBag.Message = string.Empty;
         }

         CustomerIndexViewModel vm = new CustomerIndexViewModel();
         vm.LoadAll();                        
         return View(vm);
      }

      [HttpPost]
      public ActionResult Index(CustomerIndexViewModel viewModel)
      {
         ViewBag.Message = string.Empty;
         viewModel.LoadAll();
         return View(viewModel);
      }

      public ActionResult Details(int id)
      {
         CustomerDetailsViewModel vm = new CustomerDetailsViewModel();
         vm.Load(id);
         return View(vm);
      }

      public ActionResult Edit(int id)
      {
         CustomerDetailsViewModel vm = new CustomerDetailsViewModel();        
         vm.Load(id);
         return View(vm);
      }

      [HttpPost]
      public ActionResult Edit(CustomerDetailsViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.UpdateName = this.User.Identity.Name;
            viewModel.Update();
            result = RedirectToAction("Details", new { id = viewModel.CustomerId });
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError("Exception", ex);
            result = View(viewModel);
         }

         return result;
      }

      public ActionResult Create()
      {
         CustomerDetailsViewModel vm = new CustomerDetailsViewModel();         
         return View(vm);
      }

      [HttpPost]
      public ActionResult Create(CustomerDetailsViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.InsertName = this.User.Identity.Name;
            viewModel.Insert();
            result = RedirectToAction("Details", new { id = viewModel.CustomerId });
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError("Exception", ex);
            result = View(viewModel);
         }

         return result;
      }

      public ActionResult Delete(int id)
      {
         CustomerDetailsViewModel vm = new CustomerDetailsViewModel();
         vm.Load(id);
         return View(vm);
      }

      [HttpPost]
      public ActionResult Delete(CustomerDetailsViewModel viewModel)
      {
         ActionResult result = null;

         try
         {          
            viewModel.Delete();
            this.UserSession.CustomerDeletedMessage = string.Format("Customer {0} deleted.", viewModel.CustomerId);
            result = RedirectToAction("Index");
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError("Exception", ex.Message);
            viewModel.Load(viewModel.CustomerId);
            result = View(viewModel);
         }

         return result;
      }
   }
}
