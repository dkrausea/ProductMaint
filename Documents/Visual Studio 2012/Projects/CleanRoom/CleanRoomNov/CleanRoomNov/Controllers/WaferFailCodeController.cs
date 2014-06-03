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
    public class WaferFailCodeController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //
        // GET: /WaferFailCode/

        public ActionResult Index()
        {
            return View(db.WaferFailCodes.ToList());
        }

        //
        // GET: /WaferFailCode/Details/5

        public ActionResult Details(int id = 0)
        {
            WaferFailCode waferfailcode = db.WaferFailCodes.Find(id);
            if (waferfailcode == null)
            {
                return HttpNotFound();
            }
            return View(waferfailcode);
        }

        //
        // GET: /WaferFailCode/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WaferFailCode/Create

        [HttpPost]
        public ActionResult Create(WaferFailCode waferfailcode)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                waferfailcode.CreatedBy = Uin;
                waferfailcode.CreatedOn = DateTime.Now;
                waferfailcode.ModifiedBy = Uin;
                waferfailcode.ModifiedOn = DateTime.Now;

                db.WaferFailCodes.Add(waferfailcode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waferfailcode);
        }

        //
        // GET: /WaferFailCode/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WaferFailCode waferfailcode = db.WaferFailCodes.Find(id);
            if (waferfailcode == null)
            {
                return HttpNotFound();
            }
            return View(waferfailcode);
        }

        //
        // POST: /WaferFailCode/Edit/5

        [HttpPost]
        public ActionResult Edit(WaferFailCode waferfailcode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waferfailcode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waferfailcode);
        }

        //
        // GET: /WaferFailCode/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WaferFailCode waferfailcode = db.WaferFailCodes.Find(id);
            if (waferfailcode == null)
            {
                return HttpNotFound();
            }
            return View(waferfailcode);
        }

        //
        // POST: /WaferFailCode/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WaferFailCode waferfailcode = db.WaferFailCodes.Find(id);
            db.WaferFailCodes.Remove(waferfailcode);
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