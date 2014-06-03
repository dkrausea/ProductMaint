using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcFFA_SURF.Models
{
    public class Release
    {
                   
        public int ReleaseID { get; set; }
        public int ATPID { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string ReleasedBy { get; set; }
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }

        public virtual ATP ATP { get; set; }
    }
}