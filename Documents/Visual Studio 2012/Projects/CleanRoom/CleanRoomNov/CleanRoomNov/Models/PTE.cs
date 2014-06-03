using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanRoom.Models
{
    public class PTE
    {
        public int PTEID { get; set; }
        public string Name { get; set; }    //ie:  c_aeste, dkrause
        public string Email { get; set; }   //ie:  c_aeste@qti.qualcomm.com, dkrause@qti.qualcomm.com

        //---Navigation Links
        public int MCNID { get; set; }        // ForeignKey to a MCN:  ie CD90
        public virtual MCN MCN { get; set; }  // Points back to MCN

        public virtual ICollection<WaferLot> WaferLots { get; set; } //List of WaferLots that PTE is assigned to 
        public virtual ICollection<Project> Projects { get; set; }   //List to Projects that PTE is assigned to

        //----    Book keeping information
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }      
    }
}