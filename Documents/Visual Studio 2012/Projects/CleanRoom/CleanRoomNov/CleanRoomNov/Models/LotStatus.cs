using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CleanRoom.Models
{
    public class LotStatus
    {
        public int LotStatusID { get; set; }
        [Display(Name = "Lot Status")]
        public string Name { get; set; }    // Available, Shipped, Archive etc

        //----    Book keeping information
        //[Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        //[Required]  
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<WaferLot> WaferLots { get; set; }  // Used to show all Shipped, or Archive Lots etc
    }
}