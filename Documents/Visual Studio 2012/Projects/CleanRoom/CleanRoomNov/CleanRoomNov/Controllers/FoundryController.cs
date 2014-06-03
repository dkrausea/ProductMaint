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
    public class FoundryController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /Foundry/

        public ActionResult Index()
        {
            return View(db.Foundries.ToList());
        }

        //
        // GET: /Foundry/Details/5

        public ActionResult Details(int id = 0)
        {
            Foundry foundry = db.Foundries.Find(id);
            if (foundry == null)
            {
                return HttpNotFound();
            }
            return View(foundry);
        }

        //
        // GET: /Foundry/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Foundry/Create

        [HttpPost]
        public ActionResult Create(Foundry foundry)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                foundry.CreatedBy = Uin;
                foundry.CreatedOn = DateTime.Now;
                foundry.ModifiedBy = Uin;
                foundry.ModifiedOn = DateTime.Now;

                db.Foundries.Add(foundry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foundry);
        }

        //
        // GET: /Foundry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Foundry foundry = db.Foundries.Find(id);
            if (foundry == null)
            {
                return HttpNotFound();
            }
            return View(foundry);
        }

        //
        // POST: /Foundry/Edit/5

        [HttpPost]
        public ActionResult Edit(Foundry foundry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foundry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foundry);
        }

        //
        // GET: /Foundry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Foundry foundry = db.Foundries.Find(id);
            if (foundry == null)
            {
                return HttpNotFound();
            }
            return View(foundry);
        }

        //
        // POST: /Foundry/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Foundry foundry = db.Foundries.Find(id);
            db.Foundries.Remove(foundry);
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