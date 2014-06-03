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
    public class ChipRequestController : Controller
    {
        private MvcFFA_SURFContext db = new MvcFFA_SURFContext();

        //
        // GET: /ChipRequest/

        public ActionResult Index()
        {
            
            return View(db.ChipRequests.ToList());
        }

        //
        // GET: /ChipRequest/Details/5


        public ActionResult Details( int id = 0 )
        {
            ChipRequest chipRequest = db.ChipRequests.Find(id);
            if (chipRequest == null)
            {
                return HttpNotFound();
            }
            return View(chipRequest);
        }

        //
        // GET: /ChipRequest/Create

        public ActionResult Create()
        {
            PopulateMcnDropDownList();
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
                db.ChipRequests.Add(chiprequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateMcnDropDownList();
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
            PopulateMcnDropDownList(chiprequest.MCNumberID);
            return View(chiprequest);
        }

        //
        // POST: /ChipRequest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChipRequest chiprequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(chiprequest).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable ToString save DropCreateDatabaseIfModelChanges. Try again, and if the problem persists, see your administrator.");
            }
            PopulateMcnDropDownList(chiprequest.MCNumberID);
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

        private void PopulateMcnDropDownList( object selectedMCNumber = null )
        {
            var mcnQuery = from d in db.MCNs
                           orderby d.MCN
                           select d;
            ViewBag.MCNumberID = new SelectList(mcnQuery, "MCNumberID", "MCN", selectedMCNumber);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}