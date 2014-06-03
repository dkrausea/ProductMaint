using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CleanRoom.Models
{
    public class Foundry
    {
        public int FoundryID { get; set; }
        [Display(Name = "Foundry")]
        public string Name { get; set; }

        public string Note { get; set; }

        //----    Navigation LInks
        public virtual ICollection<WaferLot> WaferLots { get; set; }   // L-List to all Wafers from this Foundry

        //----    Bookkeeping info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
} 