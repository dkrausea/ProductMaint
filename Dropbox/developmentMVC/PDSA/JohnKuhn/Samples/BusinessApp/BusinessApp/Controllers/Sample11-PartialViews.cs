using System;
using System.Web.Mvc;
using BusinessApp.BusinessLayer;
using BusinessApp.ViewModels;

namespace MVCSample.Website.Controllers
{
   /// <summary>
   /// Demonstrates a complete list, details, add, edit and delete 
   /// feature using separate views for each action.
   /// </summary>
   public class Sample11Controller : Controller
   {
      #region Index

      // Get the list of timesheets 
      public ActionResult Index(TimesheetViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.IsEditPanelVisible = false;
            viewModel.LoadTimesheet();
            result = View(viewModel);
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError(string.Empty, ex.Message);
            result = View(viewModel);
         }

         return result;
      }

      #endregion

      #region Create Get

      // Initialize a new 'empty' model for 
      public ActionResult Create()
      {
         ActionResult result = null;
         TimesheetViewModel viewModel = new TimesheetViewModel();

         try
         {
            viewModel.IsEditPanelVisible = true;
            viewModel.LoadTimesheet();
            viewModel.TimesheetEntry = new TimesheetEntry();

            result = View("Index", viewModel);
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError(string.Empty, ex.Message);
            result = View("Index", viewModel);
         }

         return result;
      }

      #endregion

      #region Create Post

      // Handle the form post action 
      [HttpPost]
      public ActionResult Create(TimesheetViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.Save();
            result = RedirectToAction("Index");
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError(string.Empty, ex.Message);
            viewModel.IsEditPanelVisible = true;
            viewModel.LoadTimesheet();
            result = result = View("Index", viewModel);
         }

         return result;
      }

      #endregion

      #region Edit

      // Retrieve an instance 
      public ActionResult Edit(int id)
      {
         ActionResult result = null;
         TimesheetViewModel viewModel = new TimesheetViewModel();

         try
         {
            viewModel.IsEditPanelVisible = true;
            viewModel.Load(id);
            viewModel.LoadTimesheet();
            result = View("Index", viewModel);
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError(string.Empty, ex.Message);
            result = View("Index", viewModel);
         }

         return result;
      }

      #endregion

      #region Edit Post

      [HttpPost]
      public ActionResult Edit(TimesheetViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.Save();
            result = RedirectToAction("Index");
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError(string.Empty, ex);
            viewModel.Load(viewModel.TimesheetEntry.TimesheetEntryId);
            result = View(viewModel);
         }

         return result;
      }

      #endregion

      #region Delete

      public ActionResult Delete(int id)
      {
         ActionResult result = null;
         TimesheetViewModel viewModel = new TimesheetViewModel();

         try
         {
            viewModel.IsEditPanelVisible = false;
            viewModel.Delete(id);
            viewModel.LoadTimesheet();
            result = View("Index", viewModel);
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError(string.Empty, ex.Message);
            result = View("Index", viewModel);
         }

         return result;
      }

      #endregion
   }
}
