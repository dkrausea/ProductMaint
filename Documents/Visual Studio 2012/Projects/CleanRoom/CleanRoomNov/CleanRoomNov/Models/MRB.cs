using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CleanRoom.Models
{
//   MRB Cabinets
//---------------------------------------------------------------------------------
//               5                6                  7                   8
//Shelf 1  5,1,1 | 5,1,2    6,1,1 | 6,1,2      7,1,1 | 7,1,2       8,1,1 | 8,1,2
//Shelf ....
//Shelf 4  5,4,1 | 5,4,2        ......            .......          8,4,1 | 8,4,2
//--------------------------------------------------------------------------------
    public class MRB
    {
        public int MRBID { get; set; }
        public string Name { get; set; }            // m_name

        //------  Location Information of HomeBoat Container   ------
        // Can be located in Cabinets 5 - 8, with 2 spots (1 or 2), 4 Shelves
        public int Cabinet { get; set; }            //       5,6,7, or 8
        public int Shelf { get; set; }              //       1 thru 4
        public int Spot { get; set; }               //       1 or 2
        public int LocCode { get; set; }            //       511


        public string Note { get; set; }

        //----    Bookkeeping info
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}