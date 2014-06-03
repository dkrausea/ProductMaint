using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcChipRequest.Models
{
    public class Demand
    {
        [Display(Name = "Demand ID")]
        public int DemandID { get; set; }

        //FKeys
        public int ChipRequestID { get; set; }
        public int DemandStatusID { get; set; }

        [Display(Name="PM/PA")]
        public string PMPA { get; set; }

        [Required(ErrorMessage = "At least one Demand Planner is required.")]
        public string Planners { get; set; }

        public int Quantity { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Needed By")]
        public DateTime NeededBy { get; set; }

        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Modified By")]
        public string ModifideBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }

        [Display(Name = "Partial")]
        public bool PartialRelease { get; set; }



        public virtual ChipRequest ChipRequest { get; set; }
        public virtual DemandStatus DemandStatus { get; set; }
        public virtual ICollection<ATP> ATPs { get; set; }

        //public virtual ICollection<DemandStatus> DemandStatuses { get; set; }

        //The word this in the code below means this class Demand{}

        // Read Only Get that SUMs the ATP quantities for this Demand
        public int ATPSum
        {
            get
            {

                int i = 0;

                if (this.ATPs != null)
                    if (this.ATPs.Count > 0)
                        i = this.ATPs.Sum(a => a.Quantity);

                return i;
            }
        }

        // Read only Get that subtracts the ATPSum from the Demand Quantity
        public int ATPDelta
        {
            get
            {

                int i = 0;

                i = this.Quantity - this.ATPSum;

                return i;
            }
        }


        // This read-only property gets the total release quantity for this Demand
        public int ReleaseQuantity
        {
            get
            {
                int i = 0;
                if (this.ATPs != null)
                {
                    foreach (var item in this.ATPs)
                    {
                        if (item.Releases != null)
                        {
                            foreach (var release in item.Releases)
                            {
                                i += release.Quantity;
                            }
                        }

                    }
                }
                return i;
            }
        }




        // Calculates the quantity that still needs to be released by subtracting the released quantity from the demand quantity for this demand
        public int OpenDemand 
        
        {
            get
            {
                int i = 0;

                i = this.Quantity - this.ReleaseQuantity;

                return i;
            }
        }

    }
}
