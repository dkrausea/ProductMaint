using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
   public class Release
   {
      public int ReleaseID { get; set; }
      public int ATPID { get; set; }

      public int Quantity { get; set; }

      
      [Display(Name = "Released By")]
      public string ReleasedBy { get; set; }

      [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
      [Display(Name = "Released")]
      public DateTime ReleaseDate { get; set; }
      
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

      public virtual ATP ATP { get; set; }
   }
}