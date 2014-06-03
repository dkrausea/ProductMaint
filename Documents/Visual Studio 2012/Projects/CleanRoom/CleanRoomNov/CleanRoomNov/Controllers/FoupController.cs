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
    public class FoupController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /Foup/

        public ActionResult Index()
        {
            var foups = db.Foups.Include(f => f.Location);
            return View(foups.ToList());
        }

        //
        // GET: /Foup/Details/5

        public ActionResult Details(int id = 0)
        {
            Foup foup = db.Foups.Find(id);
            if (foup == null)
            {
                return HttpNotFound();
            }
            return View(foup);
        }

        //
        // GET: /Foup/Create

        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name");
            return View();
        }

        //
        // POST: /Foup/Create

        [HttpPost]
        public ActionResult Create(Foup foup)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                foup.CreatedBy = Uin;
                foup.CreatedOn = DateTime.Now;
                foup.ModifiedBy = Uin;
                foup.ModifiedOn = DateTime.Now;

                db.Foups.Add(foup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name", foup.LocationID);
            return View(foup);
        }

        //
        // GET: /Foup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Foup foup = db.Foups.Find(id);
            if (foup == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name", foup.LocationID);
            return View(foup);
        }

        //
        // POST: /Foup/Edit/5

        [HttpPost]
        public ActionResult Edit(Foup foup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name", foup.LocationID);
            return View(foup);
        }

        //
        // GET: /Foup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Foup foup = db.Foups.Find(id);
            if (foup == null)
            {
                return HttpNotFound();
            }
            return View(foup);
        }

        //
        // POST: /Foup/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Foup foup = db.Foups.Find(id);
            db.Foups.Remove(foup);
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