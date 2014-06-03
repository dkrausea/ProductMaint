using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class TourController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: /Tour/
        public ActionResult Index()
        {
            var tours = db.Tours.Include(t => t.Rating);
            return View(tours.ToList());
        }

        public ActionResult Difficult()
        {
            //var tours = db.Tours.Include(t => t.Rating).Where(t => t.Rating.Name == "Difficult").OrderBy(t => t.Name);
            var tours = from t in db.Tours
                        where t.Rating.Name == "Difficult"
                        orderby t.Name
                        select t;            
            return View(tours.ToList());
        }

        // GET: /Tour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: /Tour/Create
        public ActionResult Create()
        {
            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "Name");
            return View();
        }

        // POST: /Tour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,Length,Price,RatingId,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "Name", tour.RatingId);
            return View(tour);
        }

        // GET: /Tour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "Name", tour.RatingId);
            return View(tour);
        }

        // POST: /Tour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,Length,Price,RatingId,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "Name", tour.RatingId);
            return View(tour);
        }

        // GET: /Tour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: /Tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
