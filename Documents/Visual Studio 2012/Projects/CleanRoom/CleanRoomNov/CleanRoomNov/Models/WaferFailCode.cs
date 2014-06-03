using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CleanRoom.Models
{
    public class WaferFailCode
    {
        public int WaferFailCodeID { get; set; }
        [Display(Name = "Failure Code")]
        public int Number { get; set; }

        public string Reason { get; set; }

        public string Note {get;set;}

        //----    Bookkeeping Info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}