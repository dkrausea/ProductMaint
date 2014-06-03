using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcFFA_SURF.Models
{
    public class Demand
    {
        public int DemandID { get; set; }
        public int ChipRequestID { get; set; }
         
        [Display(Name="DPlanners")]
        public string Planners  { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime NeededBy { get; set; }

        public string Comments { get; set; }

        [Display(Name="Created On")]
        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        public virtual ChipRequest ChipRequest { get; set; }
        public virtual ICollection<ATP> ATPs { get; set; }
    }
}