using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.DAL;
using MvcChipRequest.Models;


namespace MvcChipRequest.Controllers
{
    public class ChipRequestController : Controller
    {
        private RequestContext db = new RequestContext();

        //
        // GET: /ChipRequest/

        public ActionResult Index()
        {
           var chiprequests = db.ChipRequests.Include(c => c.Chip);

            return View(chiprequests.ToList());
        }

        //
        // GET: /ChipRequest/Details/5

        public ActionResult Details(int id = 0)
        {
            ChipRequest chiprequest = db.ChipRequests.Find(id);
            if (chiprequest == null)
            {
                return HttpNotFound();
            }
            return View(chiprequest);
        }

        //
        // GET: /ChipRequest/Create

        public ActionResult Create()
        {
            ViewBag.ChipID = new SelectList(db.Chips, "ChipID", "MCN");
            return View();
        }

        //
        // POST: /ChipRequest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChipRequest chiprequest)
        {
            if (ModelState.IsValid)
            {
               chiprequest.CreatedBy = Environment.UserName;
               chiprequest.CreatedOn = DateTime.Now;
               chiprequest.IsActive = bool.Parse("True");
               chiprequest.ModifiedOn = DateTime.Now;

                db.ChipRequests.Add(chiprequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChipID = new SelectList(db.Chips, "ChipID", "MCN", chiprequest.ChipID);
            return View(chiprequest);
        }

        //
        // GET: /ChipRequest/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChipRequest chiprequest = db.ChipRequests.Find(id);
            if (chiprequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChipID = new SelectList(db.Chips, "ChipID", "MCN", chiprequest.ChipID);
            return View(chiprequest);
        }

        //
        // POST: /ChipRequest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChipRequest chiprequest)
        {
            if (ModelState.IsValid)
            {
               chiprequest.ModifideBy = Environment.UserName;
               chiprequest.ModifiedOn = DateTime.Now;


                db.Entry(chiprequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChipID = new SelectList(db.Chips, "ChipID", "MCN", chiprequest.ChipID);
            return View(chiprequest);
        }

        //
        // GET: /ChipRequest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChipRequest chiprequest = db.ChipRequests.Find(id);
            if (chiprequest == null)
            {
                return HttpNotFound();
            }
            return View(chiprequest);
        }

        //
        // POST: /ChipRequest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChipRequest chiprequest = db.ChipRequests.Find(id);
            db.ChipRequests.Remove(chiprequest);
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