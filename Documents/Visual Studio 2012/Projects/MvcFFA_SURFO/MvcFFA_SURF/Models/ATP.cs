using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcFFA_SURF.Models
{
    public class ATP
    {
        
        public int ATPID { get; set; }
        public int DemandID { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpectedBy { get; set; }

        public String PMPA { get; set; }
        public String Comments { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }

        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }

        public virtual Demand Demand { get; set; }
        public virtual ICollection<Release> Releases { get; set; }
    }
}