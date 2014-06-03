using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.DAL;
using MvcChipRequest.Models;
using MvcChipRequest.ViewModels;


namespace MvcChipRequest.Controllers
{
    public class HomeController : Controller
    {
        private RequestContext _db = new RequestContext();

        public ViewResult SiteDown()
        {
            return View();
        }
        public ActionResult Index()
        {
            return RedirectToAction("GTW", "ChipRequest");
        }

        //Not functional yet
        //public ActionResult IndexDelete()
        //{
        //    var chiprequests = _db.ChipRequests
        //        .OrderBy(c => c.CreatedOn)
        //        .Select(c => new ChipRequestList
        //        {
        //            ChipID = c.ChipID,
        //            ChipRequestID = c.ChipRequestID,
        //            CreatedOn = c.CreatedOn,
        //            MCN = c.Chip.MCN,
        //            Description = c.Chip.Description,
        //            Quantity = c.Quantity,
        //        });
        //    return View(chiprequests.ToList());
        
        //}


        [Authorize(Roles = "ChipRequest")]
        public ActionResult Active(string searchTerm = null)
        {
            var chiprequests = _db.ChipRequests // LINQ Action 1 Obtain Data Source
                //Extension Method Syntax - LINQ Action 2 Create the query
                               .OrderBy(c => c.CreatedOn)
                               .Where(c => searchTerm == null && c.IsActive == true || c.Chip.MCN.Contains(searchTerm) && c.IsActive == true)
                               .Select(c => new ChipRequestList
                                        {
                                            ChipID = c.ChipID,
                                            ChipRequestID = c.ChipRequestID,
                                            CreatedOn = c.CreatedOn,
                                            MCN = c.Chip.MCN,
                                            Description = c.Chip.Description,
                                            Quantity = c.Quantity,
                                        });
            return View(chiprequests.ToList()); // LINQ Action 3 Execute the query
        }

        [Authorize(Roles = "ChipRequest")]
        public ActionResult InActiveList(string searchTerm = null)
        {
            var chiprequests = _db.ChipRequests // LINQ Action 1 Obtain Data Source
                //Extension Method Syntax - LINQ Action 2 Create the query
                               .OrderBy(c => c.CreatedOn)
                               .Where(c => searchTerm == null && c.IsActive == false || c.Chip.MCN.Contains(searchTerm) && c.IsActive == false)
                               .Select(c => new ChipRequestList
                               {
                                   ChipID = c.ChipID,
                                   ChipRequestID = c.ChipRequestID,
                                   CreatedOn = c.CreatedOn,
                                   MCN = c.Chip.MCN,
                                   Description = c.Chip.Description,
                                   Quantity = c.Quantity,
                               });
            return View(chiprequests.ToList()); // LINQ Action 3 Execute the query
        }

        [Authorize(Roles = "ChipRequest")]
        public ActionResult About()
        {
            ViewBag.Message = "Development";

            return View();
        }

        [Authorize(Roles = "ChipRequest")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Don Krause";
            return View();
        }
    }
}
