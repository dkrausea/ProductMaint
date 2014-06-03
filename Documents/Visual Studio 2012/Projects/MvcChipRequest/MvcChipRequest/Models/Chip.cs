using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
   public class Chip
   {
      public int ChipID { get; set; }

      [Required(ErrorMessage = "MCN is required.")]
      public string MCN { get; set; }

      [MaxLength(255)]
      [Required(ErrorMessage = "Description is required.")]
      public string Description { get; set; }

      [Display( Name = "Active")]
      public bool IsActive { get; set; }

      [Display(Name = "Created By")]
      public string CreatedBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Created On")]
      public DateTime CreatedOn { get; set; }

      [Display(Name = "Modified By")]
      public string ModifiedBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Modified On")]
      public DateTime ModifiedOn { get; set; }

      public virtual ICollection<ChipRequest> ChipRequests { get; set; }       
   }
}