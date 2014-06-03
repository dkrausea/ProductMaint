using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
    public class ChipRequest
    {
        [Display(Name = "Chip Request ID")]
        public int ChipRequestID { get; set; }

        public int ChipID { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public string ModifideBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }

        [Display(Name = "Completed By")]
        public string CompletedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Completed On")]
        public DateTime? CompletedOn { get; set; }

        public virtual Chip Chip { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }


        //Read Only Properites

        public int DemandTotal
        {
            get
            {
                int i = 0;

                if (this.Demands != null)
                    if (this.Demands.Count > 0)
                        i = this.Demands.Sum(a => a.Quantity);
                return i;
            }
        }

        public int ReleaseTotal
        {
            get
            {
                int i = 0;


                if (this.Demands != null)
                {
                    foreach (var item in this.Demands)
                    {
                        if (item.ATPs != null)
                        {
                            foreach (var atp in item.ATPs)
                            {
                                i += atp.Releases.Sum(a => a.Quantity);
                            }
                        }
                    }
                }
                return i;
            }
        }
        public int OpenQuantity
        {
            get
            {
                int i = 0;
                i = this.DemandTotal - this.ReleaseTotal;
                return i;
            }
        }
    }
}
