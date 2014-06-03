using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcChipRequest.DAL;
using MvcChipRequest.Models;

namespace MvcChipRequest.ViewModels
{
   public class ChipRequestList
   {
       private RequestContext _db = new RequestContext();

      public int ChipID { get; set; }
      public int ChipRequestID { get; set; }
      public DateTime CreatedOn { get; set; }
      public string MCN { get; set; }
      public string Description { get; set; }
      public bool IsActive { get; set; }
      

      // Set to contant 0 as of 11/1/2013  
      public int Quantity { get; set; }

   }
}