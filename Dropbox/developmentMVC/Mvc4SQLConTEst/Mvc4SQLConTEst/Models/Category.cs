using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
   public class Category
   {
      public int CategoryID { get; set; }

      [Required(ErrorMessage = "Category Name is required.")]
      [Display(Name = "Category Name")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Category Description is required.")]
      [Display(Name = "Description")]
      public string Description { get; set; }

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

      public virtual ICollection<Person> People { get; set; }
   }
}