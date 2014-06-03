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
    public class PTEController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /PTE/

        public ActionResult Index()
        {
            var ptes = db.PTEs.Include(p => p.MCN);
            return View(ptes.ToList());
        }

        //
        // GET: /PTE/Details/5

        public ActionResult Details(int id = 0)
        {
            PTE pte = db.PTEs.Find(id);
            if (pte == null)
            {
                return HttpNotFound();
            }
            return View(pte);
        }

        //
        // GET: /PTE/Create

        public ActionResult Create()
        {
            ViewBag.MCNID = new SelectList(db.MCNs, "MCNID", "Name");
            return View();
        }

        //
        // POST: /PTE/Create

        [HttpPost]
        public ActionResult Create(PTE pte)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                pte.CreatedBy = Uin;
                pte.CreatedOn = DateTime.Now;
                pte.ModifiedBy = Uin;
                pte.ModifiedOn = DateTime.Now;

                db.PTEs.Add(pte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MCNID = new SelectList(db.MCNs, "MCNID", "Name", pte.MCNID);
            return View(pte);
        }

        //
        // GET: /PTE/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PTE pte = db.PTEs.Find(id);
            if (pte == null)
            {
                return HttpNotFound();
            }
            ViewBag.MCNID = new SelectList(db.MCNs, "MCNID", "Name", pte.MCNID);
            return View(pte);
        }

        //
        // POST: /PTE/Edit/5

        [HttpPost]
        public ActionResult Edit(PTE pte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MCNID = new SelectList(db.MCNs, "MCNID", "Name", pte.MCNID);
            return View(pte);
        }

        //
        // GET: /PTE/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PTE pte = db.PTEs.Find(id);
            if (pte == null)
            {
                return HttpNotFound();
            }
            return View(pte);
        }

        //
        // POST: /PTE/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PTE pte = db.PTEs.Find(id);
            db.PTEs.Remove(pte);
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