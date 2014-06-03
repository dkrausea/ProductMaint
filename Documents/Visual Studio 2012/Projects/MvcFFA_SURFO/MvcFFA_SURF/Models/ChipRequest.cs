using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcFFA_SURF.Models
{
    public class ChipRequest
    {
        public int ChipRequestID { get; set; }
        public int MCNumberID { get; set; }

        [Required]
        [Display(Name = "CR Planners")]
        public string Planners { get; set; }

        [Range(1, 10000)]
        public int Quantity { get; set; }

        [Display(Name = "Needed By")]
        [DataType(DataType.Date)]
        public DateTime NeededBy { get; set; }

        public string Comments { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Completed On")]
        [DataType(DataType.Date)]
        public DateTime? CompletedOn { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Completed By")]
        public string CompletedBy { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public virtual MCNumber MCNumber { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }

    }
}