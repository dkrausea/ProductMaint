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
    public class HomeBoatController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /HomeBoat/

        public ActionResult Index()
        {
            return View(db.HomeBoats.ToList());
        }

        //
        // GET: /HomeBoat/Details/5

        public ActionResult Details(int id = 0)
        {
            HomeBoat homeboat = db.HomeBoats.Find(id);
            if (homeboat == null)
            {
                return HttpNotFound();
            }
            return View(homeboat);
        }

        //
        // GET: /HomeBoat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HomeBoat/Create

        [HttpPost]
        public ActionResult Create(HomeBoat homeboat)
        {
            var Uin = User.Identity.Name.Substring(3);
            if (ModelState.IsValid)
            {
                homeboat.MRBWafer = false;
                homeboat.IsAvailable = true;
                homeboat.CreatedBy = Uin;
                homeboat.CreatedOn = DateTime.Now;
                homeboat.ModifiedBy = Uin;
                homeboat.ModifiedOn = DateTime.Now;

                db.HomeBoats.Add(homeboat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeboat);
        }

        //
        // GET: /HomeBoat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            HomeBoat homeboat = db.HomeBoats.Find(id);
            if (homeboat == null)
            {
                return HttpNotFound();
            }
            return View(homeboat);
        }

        //
        // POST: /HomeBoat/Edit/5

        [HttpPost]
        public ActionResult Edit(HomeBoat homeboat)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                homeboat.CreatedBy = Uin;
                homeboat.CreatedOn = DateTime.Now;
                homeboat.ModifiedBy = Uin;
                homeboat.ModifiedOn = DateTime.Now;
            
                db.Entry(homeboat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeboat);
        }

        //
        // GET: /HomeBoat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            HomeBoat homeboat = db.HomeBoats.Find(id);
            if (homeboat == null)
            {
                return HttpNotFound();
            }
            return View(homeboat);
        }

        //
        // POST: /HomeBoat/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeBoat homeboat = db.HomeBoats.Find(id);
            db.HomeBoats.Remove(homeboat);
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