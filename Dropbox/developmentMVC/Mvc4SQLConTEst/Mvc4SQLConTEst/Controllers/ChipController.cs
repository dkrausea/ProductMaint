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
    public class ChipController : Controller
    {
        private RequestContext db = new RequestContext();

        //
        // GET: /Chip/

        public ActionResult Index()
        {
            return View(db.Chips.ToList());
        }

        //
        // GET: /Chip/Details/5

        public ActionResult Details(int id = 0)
        {
            Chip chip = db.Chips.Find(id);
            if (chip == null)
            {
                return HttpNotFound();
            }
            return View(chip);
        }

        //
        // GET: /Chip/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Chip/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chip chip)
        {
            if (ModelState.IsValid)
            {
               chip.CreatedBy = Environment.UserName;
               chip.CreatedOn = DateTime.Now;
               chip.IsActive = bool.Parse("True");

                db.Chips.Add(chip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chip);
        }

        //
        // GET: /Chip/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Chip chip = db.Chips.Find(id);
            if (chip == null)
            {
                return HttpNotFound();
            }
            return View(chip);
        }

        //
        // POST: /Chip/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chip chip)
        {
            if (ModelState.IsValid)
            {
               
               chip.ModifiedBy = Environment.UserName;
               chip.ModifiedOn = DateTime.Now;

               db.Entry(chip).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");

            }
            return View(chip);
        }

        //
        // GET: /Chip/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Chip chip = db.Chips.Find(id);
            if (chip == null)
            {
                return HttpNotFound();
            }
            return View(chip);
        }

        //
        // POST: /Chip/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chip chip = db.Chips.Find(id);
            db.Chips.Remove(chip);
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