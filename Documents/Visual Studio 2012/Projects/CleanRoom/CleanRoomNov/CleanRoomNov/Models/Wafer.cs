  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
// Life of a Wafer:
//
//  When it comes it, it is part of WaferLot.  So Lot is gained first and assigned a HomeBoat, AND each of the
//  individual Wafers are assigned a slot in that HomeBoat.  So WaferLot and Individual Wafers are gained together.
//  
//  When a Transaction occurs the Wafer is assigned to an appropriate container:
//
namespace CleanRoom.Models
{
    public class Wafer
    {
        public int WaferID { get; set; }
        
        [Display(Name = "Wafer ID")]
        public string Name { get; set; }           // XYZ_123.[Name]
        
        [Display(Name = "HomeBoat Slot")]
        public int HomeBoatSlot { get; set; }      // Slot in HomeBoat Container
        public int ContainerSlot { get; set; }     // Slot in Foup or Archive Container

        [Display(Name = "Wafer Status")]
        public string Status { get; set; }         // GAIN, ISSUE, RETURN, SCRAP, etc

        public string Note { get; set; }

        //----    Navigation Links
        public int WaferLotID { get; set; }             // Points back to WaferLot this wafer came from
        public virtual WaferLot WaferLot { get; set; }

        public int? FoupID { get; set; }                // If NULL, its b/c Wafer is in it's HOmeboat/Slot
        public virtual Foup Foup { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }  //LinkedList of Transactions for this Wafer

        //----    Bookkeeping Info
        public string CreatedBy { get; set; }       // These two set by the Gain Transaction (1st one)
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }      // Set by Last Transaction on this Wafer
        public DateTime ModifiedOn { get; set; }    
    }
}