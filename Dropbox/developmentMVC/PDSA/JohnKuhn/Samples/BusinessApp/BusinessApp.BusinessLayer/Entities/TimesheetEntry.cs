using System.ComponentModel.DataAnnotations;

namespace BusinessApp.BusinessLayer
{
   public class TimesheetEntry
   {
      public int TimesheetEntryId { get; set; }
      public int CustomerId { get; set; }
      public int ProjectId { get; set; }
      public int TaskId { get; set; }
      public string Description { get; set; }
      public double Hours { get; set; }
   }
}
