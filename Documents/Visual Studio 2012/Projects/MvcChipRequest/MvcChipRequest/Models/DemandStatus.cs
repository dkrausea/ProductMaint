using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcChipRequest.Models
{
    public class DemandStatus
    {
        public int DemandStatusID { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}