using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.Models;
using MvcChipRequest.DAL;
using MvcChipRequest.ViewModels;

namespace MvcChipRequest.Controllers
{
    public class DemandController : Controller
    {
        private RequestContext db = new RequestContext();

        //
        // GET: /Demand/

        public ActionResult Index()
        {
            var demands = db.Demands.Include(d => d.ChipRequest);
            return View(demands.ToList());
        }

        //
        // GET: /Demand/Details/5

        public ActionResult Details(int id = 0)
        {
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        //
        // GET: /Demand/Create

        public ActionResult Create()
        {
            ViewBag.ChipRequestID = new SelectList(db.ChipRequests, "ChipRequestID", "Planners");
            return View();
        }

        //
        // POST: /Demand/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Demand demand)
        {
            if (ModelState.IsValid)
            {
               demand.CreatedBy = Environment.UserName;
               demand.CreatedOn = DateTime.Now;
               demand.IsActive = bool.Parse("True");   

                db.Demands.Add(demand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChipRequestID = new SelectList(db.ChipRequests, "ChipRequestID", "Planners", demand.ChipRequestID);
            return View(demand);
        }

        //
        // GET: /Demand/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChipRequestID = new SelectList(db.ChipRequests, "ChipRequestID", "Planners", demand.ChipRequestID);
            return View(demand);
        }

        //
        // POST: /Demand/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Demand demand)
        {
            if (ModelState.IsValid)
            {
               demand.ModifideBy = Environment.UserName;
               demand.ModifiedOn = DateTime.Now;
               
               db.Entry(demand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChipRequestID = new SelectList(db.ChipRequests, "ChipRequestID", "Planners", demand.ChipRequestID);
            return View(demand);
        }

        //
        // GET: /Demand/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        //
        // POST: /Demand/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demand demand = db.Demands.Find(id);
            db.Demands.Remove(demand);
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