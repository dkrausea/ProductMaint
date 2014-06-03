using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapExercise.Models;
using BootstrapExercise.DAL;

namespace BootstrapExercise.Controllers
{
    public class GunController : Controller
    {
        private GunContext db = new GunContext();

        //
        // GET: /Gun/

        public ActionResult Index()
        {
            return View(db.Guns.ToList());
        }

        //
        // GET: /Gun/Details/5

        public ActionResult Details(int id = 0)
        {
            Gun gun = db.Guns.Find(id);
            if (gun == null)
            {
                return HttpNotFound();
            }
            return View(gun);
        }

        //
        // GET: /Gun/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gun/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gun gun)
        {
            if (ModelState.IsValid)
            {
                db.Guns.Add(gun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gun);
        }

        //
        // GET: /Gun/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gun gun = db.Guns.Find(id);
            if (gun == null)
            {
                return HttpNotFound();
            }
            return View(gun);
        }

        //
        // POST: /Gun/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gun gun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gun);
        }

        //
        // GET: /Gun/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gun gun = db.Guns.Find(id);
            if (gun == null)
            {
                return HttpNotFound();
            }
            return View(gun);
        }

        //
        // POST: /Gun/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gun gun = db.Guns.Find(id);
            db.Guns.Remove(gun);
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