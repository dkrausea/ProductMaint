using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
   public class ChipRequest
   {
      public int ChipRequestID { get; set; }
      public int ChipID { get; set; }

      [Required(ErrorMessage = "At least on Planner is required.")]
      public string Planners { get; set; }

      public int Quantity { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Required(ErrorMessage = "Need By date is required.")]
      [Display(Name = "Needed By")]
      [DataType(DataType.Date)]
      public DateTime NeededBy { get; set; }

      [MaxLength(255)]
      public string Comments { get; set; }

      public bool IsActive { get; set; }

      [Display(Name = "Created By")]
      public string CreatedBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Created On")]
      public DateTime CreatedOn { get; set; }

      [Display(Name = "Modified By")]
      public string ModifideBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Modified On")]
      public DateTime ModifiedOn { get; set; }

      [Display(Name = "Completed By")]
      public string CompletedBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Completed On")]
      public DateTime? CompletedOn { get; set; }

      public virtual Chip Chip { get; set; }
      public virtual ICollection<Demand> Demands { get; set; }
   }
}