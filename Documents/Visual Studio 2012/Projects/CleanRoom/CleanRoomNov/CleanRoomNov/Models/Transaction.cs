using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
// ======================TRANSACTION FLOWCHART======================================
// 
// If ISSUE, then Carrier = FOUP (Dropdown list of FOUPS).     
//                                  Wafer's Status = FOUP, and assign it to a Slot
//                                                  
// If RETURN, then Carrier = WaferLot's HomeBoat.
// If RETURN, then Carrier = NULL
//                                  Wafer's Status  = WaferLot's HomeBoat
//                                  Wafer.Slot      = Null
//
// If ARCHIVE being done, then Carrier = HomeBoat.   
// If ARCHIVE, then Carrier = NULL
//                                  Wafer's Status = ARCHIVE
//      When a WaferLot (w/indiv Wafers) is archived, there are NO ARCHIVEBOATs, 
//      The Current HomeBoat's Status is set to ARCHIVE and set in a Location of the ARCHIVE Area.
//      If some individual wafers are still in FOUPS and they finally come back to be CleanRoom
//      The HomeBoat is retrieved from ARCHIVE Area and Wafers Status set to ARCHIVE Also
//
// If SHIP being done, then Carrier = (HomeBoat? FOUP?).  
//                                  Wafer's Status = SHIP (one of 2 Types)
//                                  ?????????????????????
//                                  ????WITH ETR OR NO ETR
//
// If SCRAP, then Carrier = ??SCRAP PILE/TRASH/NULL???
//                                  Wafer's Status  = Scrap
//                                  Wafer.Slot      = NULL                
//=========================================================================================        

namespace CleanRoom.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        public int Slot { get; set; }               // Slot in Container

        public string Note { get; set; }
        
        //----    Navigation Links
        public int TransactionTypeID { get; set; }                   // Use for dropdown list for transactions
        public virtual TransactionType TransactionType { get; set; } // Gain, Issue, Ship, Scrap etc

        public int FoupID { get; set; }             // Point to Foup that this Wafer inserted in
        public virtual Foup Foup { get; set; }       // If MagicNumber (?99999?)then Wafer is in HomeBoat/HomeSlot

        public int WaferID { get; set; }            // Point back to Wafer this transaction belongs to
        public virtual Wafer Wafer { get; set; }
        
        //----    Bookkeeping Info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }       
    }
}  