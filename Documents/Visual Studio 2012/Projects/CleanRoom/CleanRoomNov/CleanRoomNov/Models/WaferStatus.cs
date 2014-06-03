using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CleanRoom.Models
{
    public class WaferStatus
    {
        public int WaferStatusID { get; set; }
        public string Status { get; set; }       // Gain,Issue, Return...

        public string Note { get; set; }

        //----    Book keeping information
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }      
    }
}