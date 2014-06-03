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
    public class MCNController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /MCN/

        public ActionResult Index()
        {
            return View(db.MCNs.ToList());
        }

        //
        // GET: /MCN/Details/5

        public ActionResult Details(int id = 0)
        {
            MCN mcn = db.MCNs.Find(id);
            if (mcn == null)
            {
                return HttpNotFound();
            }
            return View(mcn);
        }

        //
        // GET: /MCN/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MCN/Create

        [HttpPost]
        public ActionResult Create(MCN mcn)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                mcn.CreatedBy = Uin;
                mcn.CreatedOn = DateTime.Now;
                mcn.ModifiedBy = Uin;
                mcn.ModifiedOn = DateTime.Now;

                db.MCNs.Add(mcn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mcn);
        }

        //
        // GET: /MCN/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MCN mcn = db.MCNs.Find(id);
            if (mcn == null)
            {
                return HttpNotFound();
            }
            return View(mcn);
        }

        //
        // POST: /MCN/Edit/5

        [HttpPost]
        public ActionResult Edit(MCN mcn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mcn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mcn);
        }

        //
        // GET: /MCN/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MCN mcn = db.MCNs.Find(id);
            if (mcn == null)
            {
                return HttpNotFound();
            }
            return View(mcn);
        }

        //
        // POST: /MCN/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MCN mcn = db.MCNs.Find(id);
            db.MCNs.Remove(mcn);
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