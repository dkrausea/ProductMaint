using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
   public class Demand
   {
      public int DemandID { get; set; }
      public int ChipRequestID { get; set; }

      [Required(ErrorMessage = "At least on Planner is required.")]
      public string Planners { get; set; }

      public int Quantity { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Needed By")]
      public DateTime? NeededBy { get; set; }

     
      [Display(Name = "Created By")]
      public string CreatedBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Created On")]
      public DateTime CreatedOn { get; set; }

      public bool IsActive { get; set; }

      [Display(Name = "Modified By")]
      public string ModifideBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Modified On")]
      public DateTime? ModifiedOn { get; set; }

      public virtual ChipRequest ChipRequest { get; set; }
      public virtual ICollection<ATP> ATPs { get; set; }
   }
}