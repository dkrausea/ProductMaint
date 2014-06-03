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
        [Authorize(Roles = "ChipRequestCreate, opsIT.Admins")]
        public ActionResult Index()
        {
            return View(db.Chips.ToList());
        }

        //
        // GET: /Chip/Details/5

        [Authorize(Roles = "ChipRequestCreate, opsIT.Admins")]
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
        [HttpGet]
        [Authorize(Roles = "ChipRequestCreate, opsIT.Admins")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Chip/Create

        [HttpPost]
        [Authorize(Roles = "ChipRequestCreate, opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chip chip)
        {
            if (ModelState.IsValid)
            {
                chip.CreatedBy = User.Identity.Name.Substring(3);
                chip.CreatedOn = DateTime.Now;
                chip.IsActive = bool.Parse("True");
                chip.ModifiedBy = User.Identity.Name.Substring(3);
                chip.ModifiedOn = DateTime.Now;

                var result = db.Chips.Where(c => c.MCN == chip.MCN).FirstOrDefault();

                if (result == null)
                {
                    db.Chips.Add(chip);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    this.ModelState.AddModelError("", "MCN:  " + chip.MCN.ToString() + "  already exists");
                }
            }

            return View(chip);
        }

        //
        // GET: /Chip/Edit/5
        [HttpGet]
        [Authorize(Roles = "opsIT.Admins")]
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
        [Authorize(Roles = "ChipRequestDeleteEdit, opsIT.Admins")]
        public ActionResult Edit(Chip chip)
        {
            if (ModelState.IsValid)
            {

                chip.ModifiedBy = User.Identity.Name.Substring(3);
                chip.ModifiedOn = DateTime.Now;

                db.Entry(chip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(chip);
        }

        //
        // GET: /Chip/Delete/5

        [HttpGet]
        [Authorize(Roles = "ChipRequestDeleteEdit, opsIT.Admins")]
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
        [Authorize(Roles = "opsIT.Admins")]
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