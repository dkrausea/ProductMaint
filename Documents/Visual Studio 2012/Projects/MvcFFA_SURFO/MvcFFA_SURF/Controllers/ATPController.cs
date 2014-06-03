using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFFA_SURF.Models;

namespace MvcFFA_SURF.Controllers
{
    public class ATPController : Controller
    {
        private MvcFFA_SURFContext db = new MvcFFA_SURFContext();

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

        public ActionResult Create()
        {
            ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "DemandID");
            return View();
        }

        //
        // POST: /ATP/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ATP atp)
        {
            if (ModelState.IsValid)
            {
                db.ATPs.Add(atp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "DemandID", atp.DemandID);
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
            ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "DemandID", atp.DemandID);
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
                db.Entry(atp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DemandID = new SelectList(db.Demands, "DemandID", "DemandID", atp.DemandID);
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