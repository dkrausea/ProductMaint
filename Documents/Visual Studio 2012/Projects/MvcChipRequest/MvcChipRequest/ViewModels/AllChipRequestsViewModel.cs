using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.DAL;
using MvcChipRequest.Models;


namespace MvcChipRequest.ViewModels
{
    public class AllChipRequestsViewModel
    {
        private RequestContext _db = new RequestContext();


        public List<Chip> chips { get; set; }
        public List<ChipRequest> chipRequests { get; set; }
        public List<Demand> demands { get; set; }
        public List<DemandStatus> demandStatuses { get; set; }
        public List<Release> releases { get; set; }

        public void CLoad()
        {
            try
            {
                this.chipRequests = _db.ChipRequests
                   .OrderBy(c => c.CreatedOn)
                   .Where(c => c.IsActive == true).ToList();

                this.demands = _db.Demands
                    .Where(d => d.DemandStatusID != 4)
                    .OrderBy(d => d.NeededBy)
                    .ToList<Demand>();

                this.demandStatuses = _db.DemandStatuses.ToList<DemandStatus>();
                    
                   
                if (this.chipRequests == null)
                {
                    this.IsNotFound = true;
                }
            }
            catch (Exception ex)
            {
               this.ExceptionOccured = true;
               this.ExceptionMessage = ex.Message;
            }

        }

        public void RLoad()
        {
            try
            {
                this.releases = _db.Releases
                    .OrderBy(r => r.IDF)
                    .Where(e => e.EmailSent == null)
                    .ToList();

                if (this.releases == null)
                {
                    this.IsNotFound = true;
                }
            }
            catch ( Exception ex)
            {
                this.ExceptionOccured = true;
                this.ExceptionMessage = ex.Message;
            }
        }

        public bool IsNotFound { get; set; }

        public bool ExceptionOccured { get; set; }

        public string ExceptionMessage { get; set; }
    }
}