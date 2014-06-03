using System;
using System.Web.Mvc;
using BusinessApp.Utilities;
using BusinessApp.ViewModels;

namespace BusinessApp.Controllers
{
   public class Sample10Controller : WebController
   {
      public ActionResult Index()
      {
         this.UserSession.Today = DateTime.Now;

         if (this.UserSession.EntryDeletedMessage != null)
         {
            ViewBag.Message = this.UserSession.EntryDeletedMessage;
            this.UserSession.EntryDeletedMessage = null;
         }
         else
         {
            ViewBag.Message = string.Empty;
         }

         TimesheetViewModel vm = new TimesheetViewModel();
         vm.LoadTimesheet();
         return View(vm);
      }

      [HttpPost]
      public ActionResult Index(TimesheetViewModel viewModel)
      {
         ViewBag.Message = string.Empty;
         viewModel.LoadTimesheet();
         return View(viewModel);
      }

      public ActionResult Details(int id)
      {
         TimesheetViewModel viewModel = new TimesheetViewModel();
         viewModel.Edit(id);
         return View(viewModel);
      }

      public ActionResult Edit(int id)
      {
         TimesheetViewModel viewModel = new TimesheetViewModel();
         viewModel.Edit(id);
         return View(viewModel);
      }

      [HttpPost]
      public ActionResult Edit(TimesheetViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.Save();
            result = RedirectToAction("Details", new { id = viewModel.TimesheetEntryId });
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
         TimesheetViewModel vm = new TimesheetViewModel();
         return View(vm);
      }

      [HttpPost]
      public ActionResult Create(TimesheetViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.Save();
            result = RedirectToAction("Details", new { id = viewModel.TimesheetEntryId });
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
         TimesheetViewModel vm = new TimesheetViewModel();
         vm.Load(id);
         return View(vm);
      }

      [HttpPost]
      public ActionResult Delete(TimesheetViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.Delete(viewModel.TimesheetEntryId);
            this.UserSession.EntryDeletedMessage = string.Format("Timesheet entry {0} deleted.", viewModel.CustomerId);
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