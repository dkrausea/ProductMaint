using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CleanRoom.Models
{
    public class MCN
    {
        public int MCNID { get; set; }
        public string Name { get; set; }     // ie..CD90-123xxx

        public string Note { get; set; }

        //---Navigation Links
        public virtual ICollection<WaferLot> WaferLots { get; set; } //L-List to all WaferLots with this MCN (P/N)
        public virtual ICollection<PTE> PTEs { get; set; }           //L-List to PTEs for this MCN

        //---Bookkeeping Info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}