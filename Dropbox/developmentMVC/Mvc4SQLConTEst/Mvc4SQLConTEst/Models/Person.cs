using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
   public class Person
   {
      public int PersonID { get; set; }

      [Required(ErrorMessage = "Qualcomm User ID is required.")]
      [Display(Name = "User")]
      public string UserName { get; set; }

      [Required(ErrorMessage = "Last Name is required.")]
      [Display(Name = "Last")]
      public string LastName { get; set; }

      [Required(ErrorMessage = "First Name is required.")]
      [Display(Name = "First")]
      public string FirstName { get; set; }
      
      [Display(Name = "Active")]
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

      public virtual ICollection<Category> Categories { get; set; }
   }
}