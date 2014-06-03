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
    public class LotStatusController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /LotStatus/

        public ActionResult Index()
        {
            return View(db.LotStatus.ToList());
        }

        //
        // GET: /LotStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            LotStatus lotstatus = db.LotStatus.Find(id);
            if (lotstatus == null)
            {
                return HttpNotFound();
            }
            return View(lotstatus);
        }

        //
        // GET: /LotStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LotStatus/Create

        [HttpPost]
        public ActionResult Create(LotStatus lotstatus)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                lotstatus.CreatedBy = Uin;
                lotstatus.CreatedOn = DateTime.Now;
                lotstatus.ModifiedBy = Uin;
                lotstatus.ModifiedOn = DateTime.Now;

                db.LotStatus.Add(lotstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lotstatus);
        }

        //
        // GET: /LotStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LotStatus lotstatus = db.LotStatus.Find(id);
            if (lotstatus == null)
            {
                return HttpNotFound();
            }
            return View(lotstatus);
        }

        //
        // POST: /LotStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(LotStatus lotstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lotstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lotstatus);
        }

        //
        // GET: /LotStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LotStatus lotstatus = db.LotStatus.Find(id);
            if (lotstatus == null)
            {
                return HttpNotFound();
            }
            return View(lotstatus);
        }

        //
        // POST: /LotStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LotStatus lotstatus = db.LotStatus.Find(id);
            db.LotStatus.Remove(lotstatus);
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