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
    public class WaferStatusController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /WaferStatus/

        public ActionResult Index()
        {
            return View(db.WaferStatus.ToList());
        }

        //
        // GET: /WaferStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            WaferStatus waferstatus = db.WaferStatus.Find(id);
            if (waferstatus == null)
            {
                return HttpNotFound();
            }
            return View(waferstatus);
        }

        //
        // GET: /WaferStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WaferStatus/Create

        [HttpPost]
        public ActionResult Create(WaferStatus waferstatus)
        {
            var Uin = User.Identity.Name.Substring(3);
            
            if (ModelState.IsValid)
            {
                waferstatus.CreatedBy = Uin;
                waferstatus.CreatedOn = DateTime.Now;
                waferstatus.ModifiedBy = Uin;
                waferstatus.ModifiedOn = DateTime.Now;

                db.WaferStatus.Add(waferstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waferstatus);
        }

        //
        // GET: /WaferStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WaferStatus waferstatus = db.WaferStatus.Find(id);
            if (waferstatus == null)
            {
                return HttpNotFound();
            }
            return View(waferstatus);
        }

        //
        // POST: /WaferStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(WaferStatus waferstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waferstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waferstatus);
        }

        //
        // GET: /WaferStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WaferStatus waferstatus = db.WaferStatus.Find(id);
            if (waferstatus == null)
            {
                return HttpNotFound();
            }
            return View(waferstatus);
        }

        //
        // POST: /WaferStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WaferStatus waferstatus = db.WaferStatus.Find(id);
            db.WaferStatus.Remove(waferstatus);
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