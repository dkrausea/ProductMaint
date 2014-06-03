using System;
using System.ComponentModel.DataAnnotations;
using BusinessApp.BusinessLayer;

namespace BusinessApp.ViewModels
{
   public class TimesheetViewModel
   {
      #region Properties

      public TimesheetEntry TimesheetEntry { get; set; }

      private TimesheetEntryCollection _timesheet;
      public TimesheetEntryCollection Timesheet
      {
         get
         {
            if (_timesheet == null)
            {
               _timesheet = new TimesheetEntryCollection();
            }
            return _timesheet;
         }
         set
         {
            _timesheet = value;
         }
      }

      public bool IsMessageVisible { get; set; }
      public bool IsEditPanelVisible { get; set; }
      public bool IsButtonPanelVisible { get; set; }
      public string MessageText { get; set; }
      public bool RefreshGrid { get; set; }

      public int TimesheetEntryId { get; set; }
      public int CustomerId { get; set; }
      public int ProjectId { get; set; }
      public int TaskId { get; set; }
      [Required]
      [Display(Name = "Description")]
      public string Description { get; set; }
      
      [Required]
      [Display(Name = "Hours")]
      public double Hours { get; set; }

      [Display(Name = "Description")]
      public string DescriptionFilter { get; set; }

      #endregion

      public void Edit(object p)
      {
         int id = Convert.ToInt32(p);

         this.Load(id);

         this.TimesheetEntryId = this.TimesheetEntry.TimesheetEntryId;
         this.Description = this.TimesheetEntry.Description;
         this.CustomerId = this.TimesheetEntry.CustomerId;
         this.ProjectId = this.TimesheetEntry.ProjectId;
         this.TaskId = this.TimesheetEntry.TaskId;
         this.Hours = this.TimesheetEntry.Hours;

         this.IsEditPanelVisible = true;
         this.IsButtonPanelVisible = true;
      }

      public void Delete(object p)
      {
         int id = Convert.ToInt32(p);

         TimesheetManager repository = new TimesheetManager();
         repository.Delete(id);

         this.IsEditPanelVisible = false;
         this.IsButtonPanelVisible = false;

         this.RefreshGrid = true;
      }

      public void Handle(Exception ex)
      {
         this.IsMessageVisible = true;
         this.MessageText = ex.Message;
      }

      private void CreateEntry()
      {
         if (this.TimesheetEntry == null)
         {
            this.TimesheetEntry = new TimesheetEntry();
         }

         this.TimesheetEntry.TimesheetEntryId = this.TimesheetEntryId;
         this.TimesheetEntry.Description = this.Description;
         this.TimesheetEntry.Hours = this.Hours;
      }

      public void Save()
      {
         TimesheetManager repository = new TimesheetManager();

         // Create an instance and perform data conversion for web forms
         this.CreateEntry();

         if (this.TimesheetEntry.TimesheetEntryId > 0)
         {
            repository.Update(this.TimesheetEntry);
         }
         else
         {
            repository.Insert(this.TimesheetEntry);
            this.TimesheetEntryId = repository.NewPrimaryKey;
         }

         this.IsEditPanelVisible = false;
         this.IsButtonPanelVisible = false;
         this.RefreshGrid = true;
      }

      public void Cancel()
      {
         this.IsEditPanelVisible = false;
         this.IsButtonPanelVisible = false;
      }

      public void LoadTimesheet()
      {
         TimesheetManager repository = new TimesheetManager();
         this.Timesheet = repository.GetTimesheet();
      }

      public void Load(int id)
      {
         TimesheetManager repository = new TimesheetManager();
         this.TimesheetEntry = repository.Select(id);
      }

      public void Add()
      {
         this.IsEditPanelVisible = true;
         this.IsButtonPanelVisible = true;
      }
   }
}
