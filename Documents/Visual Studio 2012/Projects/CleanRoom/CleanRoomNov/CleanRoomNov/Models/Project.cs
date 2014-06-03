using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CleanRoom.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        [Display(Name = "Project")]
        public string Name { get; set; }

        public string Note { get; set; }

        //----    Navigation Links
        public virtual ICollection<WaferLot> WaferLots { get; set; }

        //----    Bookkeeping info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}