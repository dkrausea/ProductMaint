using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.Models;
using MvcChipRequest.DAL;

namespace MvcChipRequest.Controllers
{
    public class ATPController : Controller
    {
        private RequestContext db = new RequestContext();

        //
        // GET: /ATP/

        public ActionResult Index()
        {
            var atps = db.ATPs.Include(a => a.Demand);
            return View(atps.ToList());
        }

        //
        // GET: /ATP/Details/5

        public ActionResult Details(int id = 0)
        {
            ATP atp = db.ATPs.Find(id);
            if (atp == null)
            {
                return HttpNotFound();
            }
            return View(atp);
        }

        //
        // GET: /ATP/Create

        public ActionResult Create(int id)
        {
            //ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "Planners");
            return View();
        }

        //
        // POST: /ATP/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ATP atp, int id)
        {
            if (ModelState.IsValid)
            {
               atp.DemandID = id;
               atp.CreatedBy = Environment.UserName;
               atp.CreatedOn = DateTime.Now;
               atp.IsActive = bool.Parse("True");
               atp.ModifideBy = Environment.UserName;
               atp.ModifiedOn = DateTime.Now;

                db.ATPs.Add(atp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "CrPlanners", atp.DemandID);
            return View(atp);
        }

        //
        // GET: /ATP/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ATP atp = db.ATPs.Find(id);
            if (atp == null)
            {
                return HttpNotFound();
            }
            ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "CrPlanners", atp.DemandID);
            return View(atp);
        }

        //
        // POST: /ATP/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ATP atp)
        {
            if (ModelState.IsValid)
            {
               atp.ModifideBy = Environment.UserName;
               atp.ModifiedOn = DateTime.Now;

                db.Entry(atp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "Planners", atp.DemandID);
            return View(atp);
        }

        //
        // GET: /ATP/Delete/5

        public ActionResult Delete(int id = 0)
        {
           
            ATP atp = db.ATPs.Find(id);
            if (atp == null)
            {
                return HttpNotFound();
            }
            return View(atp);
        }

        //
        // POST: /ATP/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATP atp = db.ATPs.Find(id);
            db.ATPs.Remove(atp);
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