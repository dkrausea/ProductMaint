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
    public class MCNumberController : Controller
    {
        private MvcFFA_SURFContext db = new MvcFFA_SURFContext();

        //
        // GET: /MCNumber/

        public ActionResult Index()
        {
            return View(db.MCNs.ToList());
        }

        //
        // GET: /MCNumber/Details/5

        public ActionResult Details(int id = 0)
        {
            MCNumber mcnumber = db.MCNs.Find(id);
            if (mcnumber == null)
            {
                return HttpNotFound();
            }
            return View(mcnumber);
        }

        //
        // GET: /MCNumber/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /MCNumber/Create

        [HttpPost]
        public ActionResult Create(MCNumber mcnumber)
        {
            if (ModelState.IsValid)
            {
                db.MCNs.Add(mcnumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mcnumber);
        }

        //
        // GET: /MCNumber/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MCNumber mcnumber = db.MCNs.Find(id);
            if (mcnumber == null)
            {
                return HttpNotFound();
            }
            return View(mcnumber);
        }

        //
        // POST: /MCNumber/Edit/5

        [HttpPost]
        public ActionResult Edit(MCNumber mcnumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mcnumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mcnumber);
        }

        //
        // GET: /MCNumber/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MCNumber mcnumber = db.MCNs.Find(id);
            if (mcnumber == null)
            {
                return HttpNotFound();
            }
            return View(mcnumber);
        }

        //
        // POST: /MCNumber/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MCNumber mcnumber = db.MCNs.Find(id);
            db.MCNs.Remove(mcnumber);
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