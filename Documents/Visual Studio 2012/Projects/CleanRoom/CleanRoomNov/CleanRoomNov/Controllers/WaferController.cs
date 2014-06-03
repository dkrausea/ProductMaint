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
    public class WaferController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /Wafer/-----------------------------------------------------------

        public ActionResult Index()
        {
            var wafers = db.Wafers.Include(w => w.WaferLot);
            return View(wafers.ToList());
        }

        //
        // GET: /Wafer/Details/----------------------------------------------------

        public ActionResult Details(int id = 0)
        {
            Wafer wafer = db.Wafers.Find(id);
            if (wafer == null)
            {
                return HttpNotFound();
            }
            return View(wafer);
        }
        //
        // GET: /Wafer/GainWafers/----------------------------------------------------

        public ActionResult GainWafers(int id)
        {
            ViewBag.WaferLotID = new SelectList(db.WaferLots, "WaferLotID", "Name");
            ViewBag.waferlot = db.WaferLots.Find(id);

            return View();
        }
        //
        // POST: /Wafer/GainWafers------------------------------------

        [HttpPost]
        public ActionResult GainWafers(Wafer wafer, WaferLot waferlot, int id)
        {

            waferlot = db.WaferLots.Find(id);
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                wafer.WaferLotID = waferlot.WaferLotID;
                wafer.Status = "AVAILABLE";
                wafer.CreatedBy = Uin;
                wafer.CreatedOn = DateTime.Now;
                wafer.ModifiedBy = Uin;
                wafer.ModifiedOn = DateTime.Now;

                db.Wafers.Add(wafer);
                db.SaveChanges();
                return RedirectToAction("Index", "WaferLot");
            }

            ViewBag.WaferLotID = new SelectList(db.WaferLots, "WaferLotID", "Name");
            return View(wafer.WaferLotID);
        }
        //================================================================================
        //
        // GET: /Wafer/Create/----------

        public ActionResult Create(int id)
        
        {
            ViewBag.WaferLotID = new SelectList(db.WaferLots, "WaferLotID", "Name");
            ViewBag.WaferLot = db.WaferLots.Find(id);           
            return View();
        }
        //================================================================================
        //
        // POST: /Wafer/Create/----------

        [HttpPost]
       
            public ActionResult Create(Wafer wafer, WaferLot waferlot, int id)
            {
            waferlot = db.WaferLots.Find(id);              
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                wafer.Status = "AVAILABLE";
                wafer.CreatedBy = Uin;
                wafer.CreatedOn = DateTime.Now;
                wafer.ModifiedBy = Uin;
                wafer.ModifiedOn = DateTime.Now;

                db.Wafers.Add(wafer);
                db.SaveChanges();
                return RedirectToAction("Index", "WaferLot");
            }

            ViewBag.WaferLotID = new SelectList(db.WaferLots, "WaferLotID", "Name");
            return View(wafer.WaferLotID);
        }
        //================================================================================
        //
        // GET: /Wafer/Edit/----------
        //[Authorize(Users = "NA\\dkrause, NA\\c_aeste")]
        //[Authorize(Roles = "opsIT.Admins")]
        public ActionResult Edit(int id = 0)
        {
            Wafer wafer = db.Wafers.Find(id);
            if (wafer == null)
            {
                return HttpNotFound();
            }
            ViewBag.WaferLotID = new SelectList(db.WaferLots, "WaferLotID", "Name", id=wafer.WaferLotID);
            return View(wafer);
        }

        //================================================================================
        //
        // POST: /Wafer/Edit/----------
        
        [HttpPost]
//        [Authorize(Users = "NA\\dkrause")]
        public ActionResult Edit(Wafer wafer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wafer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WaferLotID = new SelectList(db.WaferLots, "WaferLotID", "Name", wafer.WaferLotID);
            return View(wafer);
        }

        //================================================================================
        //
        // GET: /Wafer/Delete/----------
        public ActionResult Delete(int id = 0)
        {
            Wafer wafer = db.Wafers.Find(id);
            if (wafer == null)
            {
                return HttpNotFound();
            }
            return View(wafer);
        }

        //================================================================================
        //
        // POST: /Wafer/Delete/----------

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Wafer wafer = db.Wafers.Find(id);
            db.Wafers.Remove(wafer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}