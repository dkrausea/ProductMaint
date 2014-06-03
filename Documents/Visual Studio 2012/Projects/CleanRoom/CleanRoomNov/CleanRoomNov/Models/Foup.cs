using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CleanRoom.Models
{
//  FOUPs are containers that Wafers are put into so they can be tested by Equipment in W185.  
//
//  They can hold 8" OR 12" Wafers.  This means that Wafers can come from different Lots.
//  Unlike Boats which should only contain wafers from one Lot.

    public class Foup   
    {
        public int FoupID { get; set; }
        [Display(Name = "Foup Container")]
        public string Name { get; set; }

        public string Note { get; set; }

        //----    Navigation Links
        public int LocationID { get; set; }                   //FK to Locations : W185, Cleanroom etc
        public virtual Location Location { get; set; }        // Points back to Location

        //----    Bookkeeping info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}