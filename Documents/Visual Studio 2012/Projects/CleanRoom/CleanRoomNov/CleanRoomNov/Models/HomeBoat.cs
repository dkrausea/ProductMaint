using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
//------  Location Information of HomeBoat Container   ------
// Regular Boats in Cleanroom are stored in 
// Cabinets 1 thru 4, on Shelves 1 thru 4, and Spots 1 thru 4
// So the LocCode [111-444] Where each digit only in range [1-4]

//------  Location Information of MRB Container   ------
// Can be located in Cabinets 5 - 8, with 2 spots (1 or 2), 4 Shelves

//==========================================   Regular     MRB

namespace CleanRoom.Models
{
    public class HomeBoat
    {
        public int HomeBoatID { get; set; }

        [Display(Name="HomeBoat")]
        public string Name { get; set; }

        public bool MRBWafer { get; set; }
        public bool IsAvailable { get; set; }

        public int Cabinet { get; set; }            //   1-4       5-8
        public int Shelf { get; set; }              //   1-4       1-4
        public int Spot { get; set; }               //   1-4       1-2
        public int LocCode { get; set; }            //   143       641

        public string Note { get; set; }


        //----    Bookkeeping info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}