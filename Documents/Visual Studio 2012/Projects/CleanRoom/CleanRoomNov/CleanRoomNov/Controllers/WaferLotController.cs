using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CleanRoom.Models;
using CleanRoom.DAL;

namespace CleanRoom.Controllers
{
    public class WaferLotController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /WaferLot/

        public ActionResult Index()
        {
            return View(db.WaferLots.ToList());
        }
        //=======================================================================================
        //
        // GET: /WaferLot/Details/5  
        // Get Details for a single WaferLot:  Listing all Wafer that
        // are part of this Lot

        public ActionResult Details(int id = 0)
        {
            WaferLot waferlot = db.WaferLots.Find(id);
            if (waferlot == null)
            {
                return HttpNotFound();
            }
            return View(waferlot);
        }
        //=======================================================================================
        //
        // GET: /WaferLot/Create

        public ActionResult Create()
        {
            ViewBag.LotStatusID = new SelectList(db.LotStatus, "LotStatusID", "Name");
            ViewBag.FoundryID = new SelectList(db.Foundries, "FoundryID", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Name");

            ViewBag.HomeBoatID = new SelectList(db.HomeBoats.Where(x => x.IsAvailable).ToList(), "HomeBoatID", "Name");
            
            return View();
        }
        //=======================================================================================
        //
        // POST: /WaferLot/Create

        [HttpPost]
        public ActionResult Create(WaferLot waferlot)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                waferlot.CreatedBy = Uin;
                waferlot.CreatedOn = DateTime.Now;
                waferlot.ModifiedBy = Uin;
                waferlot.ModifiedOn = DateTime.Now;
                waferlot.LotStatusID = 1;               // 1 = AVAILABLE
                db.WaferLots.Add(waferlot);
                db.SaveChanges();

                ViewBag.WaferLot = db.Wafers.Find(waferlot.WaferLotID);

                return RedirectToAction("GainWafers", "Wafer", new { id = waferlot.WaferLotID, qty = waferlot.WaferLotID });

                //return RedirectToAction("Create", "Wafer", new { id = wl.WaferLotID, qty = wl.Quantity }); // change parameters 

            }

            return View();
        }
        //============================================================================================
        //
        // GET: /WaferLot/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //ViewBag.LotStatusID = new SelectList(db.LotStatus, "LotStatusID", "Name");
            //ViewBag.HomeBoatID = new SelectList(db.HomeBoats, "HomeBoatID", "Name");

            WaferLot waferlot = db.WaferLots.Find(id);
            if (waferlot == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoundryID = new SelectList(db.Foundries, "FoundryID", "Name", id = waferlot.FoundryID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Name", id = waferlot.ProjectID);
            return View(waferlot);
        }
        //=======================================================================================
        //
        // POST: /WaferLot/Edit/5

        [HttpPost]
        public ActionResult Edit(WaferLot waferlot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waferlot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waferlot);
        }
        //=======================================================================================
        //
        // GET: /WaferLot/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WaferLot waferlot = db.WaferLots.Find(id);
            if (waferlot == null)
            {
                return HttpNotFound();
            }
            return View(waferlot);
        }
        //=======================================================================================
        //
        // POST: /WaferLot/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WaferLot waferlot = db.WaferLots.Find(id);
            db.WaferLots.Remove(waferlot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //=======================================================================================
        //

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}