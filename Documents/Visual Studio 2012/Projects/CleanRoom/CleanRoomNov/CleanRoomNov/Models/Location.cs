using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//  Used for FOUP Location

namespace CleanRoom.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        [Display(Name = "Foup Location")]
        public string Name { get; set; }     // W185, CleanRoom etc

        public string Note { get; set; }

        //----    Bookkeeping info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}