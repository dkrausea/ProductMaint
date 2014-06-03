using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
// When a return is done on a 12" Wafer, it COULD go into a MRB Container and be archived at the discretion of 
// Materials Mgr doing the transaction.  The MRB Container is given the same boatName as the HomeBoat of the
// WaferLot.  The reason it could go into Archive is lack of Space.  If there are sibling Wafers of the Lot
// then 12" Wafer COULD go back into the Original Boat.

// The Wafer(s) could be requested for testing at a later time, and then the wafer(s) would be directly move
// to a FOUP.  This saves the transactions/work of returning to Boat and then issuing to Foup.

namespace CleanRoom.Models
{
    public class WaferLot
    {
        public int WaferLotID { get; set; }
        [Required(ErrorMessage = "Waferlot Name Required")]
        [Display(Name = "WaferLot Name")]
        public string Name { get; set; }                //PR1-X01,   etc

        [Required(ErrorMessage = "How many Wafers are in this lot?")]
        public int Quantity { get; set; }               // # of Individual Wafers in this LOT

        public int FoundryID { get; set; }
        public virtual Foundry Foundry { get; set; }   
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }

        public string MCN { get; set; }
        public string FabLot { get; set; }              // ??  ?? ?? 
        public string Description { get; set; }         // Description

        [Display(Name = "Speed Rating")]
        public string SpeedSplits { get; set; }
        
        public string Note { get; set; }                // General Notes for this WaferLot
        
        //----    Navigation Links
        [Required(ErrorMessage = "WaferLot must be assigned to a Boat")]
        public int HomeBoatID { get; set; }                 // FK to Homecarrier,  Homeport for this Lot and its wafers
        public virtual HomeBoat HomeBoat { get; set; }

        public int LotStatusID { get; set; }              // Available, Archive, Shipped
        public virtual LotStatus LotStatus{  get; set; }  // Used for DropDown List

        public virtual ICollection<Wafer> Wafers { get; set; } // L-List to the wafers of this Lot

        //----    Book keeping information
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }        
    }
}