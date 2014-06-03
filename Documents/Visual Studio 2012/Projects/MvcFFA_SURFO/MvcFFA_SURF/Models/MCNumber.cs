using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcFFA_SURF.Models
{
    public class MCNumber
    {
        
        public int MCNUmberID { get; set; }

        [Required]
        public String MCN { get; set; }

        [Required]
        public String Description { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name="Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        
        public virtual ICollection<ChipRequest> ChipRequests { get; set; }

    }
}