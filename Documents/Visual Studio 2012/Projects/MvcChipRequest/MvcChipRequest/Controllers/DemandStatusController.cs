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
    public class DemandStatusController : Controller
    {
        private RequestContext db = new RequestContext();

        //
        // GET: /DemandStatus/
        [HttpGet]
        [Authorize(Roles="ChipRequest")]
        public ActionResult Index()
        {
            return View(db.DemandStatuses.ToList());
        }

        //
        // GET: /DemandStatus/Details/5
        [HttpGet]
        [Authorize(Roles = "ChipRequest")]
        public ActionResult Details(int id = 0)
        {
            DemandStatus demandstatus = db.DemandStatuses.Find(id);
            if (demandstatus == null)
            {
                return HttpNotFound();
            }
            return View(demandstatus);
        }

        //
        // GET: /DemandStatus/Create
        [HttpGet]
        [Authorize(Roles = "opsIT.Admins")]
        [Authorize(Roles="qct.materials, opsIT.Admins")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DemandStatus/Create

        [HttpPost]
        [Authorize(Roles = "opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DemandStatus demandstatus)
        {
            if (ModelState.IsValid)
            {
                db.DemandStatuses.Add(demandstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demandstatus);
        }

        //
        // GET: /DemandStatus/Edit/5
        [HttpGet]
        [Authorize(Roles = "opsIT.Admins")]
        public ActionResult Edit(int id = 0)
        {
            DemandStatus demandstatus = db.DemandStatuses.Find(id);
            if (demandstatus == null)
            {
                return HttpNotFound();
            }
            return View(demandstatus);
        }

        //
        // POST: /DemandStatus/Edit/5

        [HttpPost]
        [Authorize(Roles = "opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DemandStatus demandstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demandstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demandstatus);
        }

        //
        // GET: /DemandStatus/Delete/5
        [HttpGet]
        [Authorize(Roles = "opsIT.Admins")]
        public ActionResult Delete(int id = 0)
        {
            DemandStatus demandstatus = db.DemandStatuses.Find(id);
            if (demandstatus == null)
            {
                return HttpNotFound();
            }
            return View(demandstatus);
        }

        //
        // POST: /DemandStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemandStatus demandstatus = db.DemandStatuses.Find(id);
            db.DemandStatuses.Remove(demandstatus);
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