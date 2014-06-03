using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.DAL;
using MvcChipRequest.Models;

namespace MvcChipRequest.ViewModels
{
   public class ChipRequestViewModel
   {
      // underscore for private
      private RequestContext _db = new RequestContext();

      // camelCase for local method variables
      // e.g. int chipId

      // Pascal Case for properties and methods
      // public int SomethingId {...}

      public ChipRequest chipRequest  { get; set; }
      public List<Demand> demands { get; set; }
      public List<ATP> atps { get; set; }
      public List<Release> releases { get; set; }

      public void Load( int chipRequestID )
      {
         try
         {
            
            this.chipRequest = _db.ChipRequests.Find(chipRequestID);
            this.demands = _db.Demands
                .Where(d => d.ChipRequestID == chipRequestID)
                .OrderBy(d => d.NeededBy).ToList<Demand>();

            if (this.chipRequest == null)
            {
               this.IsNotFound = true;
            }
            else
            {
               //this.chips = new SelectList(_db.Chips, "ChipID", "MCN", this.chipRequest.ChipID);
            }
         }
         catch (Exception ex)
         {
            this.ExceptionOccured = true;
            this.ExceptionMessage = ex.Message;
            //TODO add some type of logger here.  ELMAH or Log4net -- both are available on NuGet
         }
      }

      public bool ExceptionOccured { get; set; }

      public bool IsNotFound { get; set; }

      public string ExceptionMessage { get; set; }

      public SelectList chips { get; set; }
   }
}