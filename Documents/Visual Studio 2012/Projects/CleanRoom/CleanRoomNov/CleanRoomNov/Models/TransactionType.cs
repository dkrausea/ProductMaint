using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CleanRoom.Models
{

    // GAIN     - just assign a WaferLot to a Homeboat, and assign each Wafer to a Slot within the HomeBoat
    // ISSUE    - Take a Wafer and assign it to a Foup and Slot 
    // RETURN   - Take the wafer from a Foup and send it back to its WaferLot HomeBoat and Slot
    // SCRAP    - This is determined by QA Inspection (Gain/Return) and Wafer.Status = Scrap
    // MISSING  - When a wafer cannot be found in it's assigned Container/Slot, then Wafer.Status = Missing
    // ARCHIVE  - Done as a whole Lot.  WaferLot/Indiv Wafers transferred to Archive Container. Status of Lot=ARCHIVE
    //          - HomeBoat Name applied to Archive Package and stored in Location T1-T11
    // Ship     -
    public class TransactionType
    {
        public int TransactionTypeID { get; set; }
        [Display(Name = "Transaction Type")]
        public string Name { get; set; }               //Gain, Issue, Return, Fail, Ship, Archive etc
        public string Note { get; set; }
        
        //----    Bookkeeping Info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}