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
    public class ReleaseController : Controller
    {
        private MvcFFA_SURFContext db = new MvcFFA_SURFContext();

        //
        // GET: /Release/

        public ActionResult Index()
        {
            var releases = db.Releases.Include(r => r.ATP);
            return View(releases.ToList());
        }

        //
        // GET: /Release/Details/5

        public ActionResult Details(int id = 0)
        {
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            return View(release);
        }

        //
        // GET: /Release/Create

        public ActionResult Create()
        {
            ViewBag.ATPID = new SelectList(db.ATPs, "ATPID", "ATPID");
            return View();
        }

        //
        // POST: /Release/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Release release)
        {
            if (ModelState.IsValid)
            {
                db.Releases.Add(release);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ATPID = new SelectList(db.ATPs, "ATPID", "ATPID", release.ATPID);
            return View(release);
        }

        //
        // GET: /Release/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            ViewBag.ATPID = new SelectList(db.ATPs, "ATPID", "ATPID", release.ATPID);
            return View(release);
        }

        //
        // POST: /Release/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Release release)
        {
            if (ModelState.IsValid)
            {
                db.Entry(release).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ATPID = new SelectList(db.ATPs, "ATPID", "ATPID", release.ATPID);
            return View(release);
        }

        //
        // GET: /Release/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return HttpNotFound();
            }
            return View(release);
        }

        //
        // POST: /Release/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Release release = db.Releases.Find(id);
            db.Releases.Remove(release);
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