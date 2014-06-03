using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
   public class ATP
   {
      public int ATPID { get; set; }
      public int DemandID { get; set; }
      public int Quantity { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Expected By")]
      public DateTime? ExpectedBy { get; set; }

      [Required(ErrorMessage = "PM/PA is required.")]
      [Display(Name= "PM/PA")]
      [MaxLength(50)]
      public string PMPA { get; set; }

      [MaxLength(255)]
      public string Comments { get; set; }

      [Display(Name ="Active")]
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
      public DateTime? ModifiedOn { get; set; }

      public virtual Demand Demand { get; set; }
      public virtual ICollection<Release> Releases { get; set; }
   }
}