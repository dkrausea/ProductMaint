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
    public class TransactionController : Controller
    {
        private CleanroomContext db = new CleanroomContext();

        //================================================================================

        // GET: /Transaction/

        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.TransactionType).Include(t => t.Foup).Include(t => t.Wafer);
            return View(transactions.ToList());
        }
        //================================================================================
        //
        // GET: /Transaction/Details/5

        public ActionResult Details(int id = 0)
        {
            Transaction transaction = db.Transactions.Find();
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //================================================================================
        //
        // GET: /Transaction/Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "Name");
            ViewBag.FoupID = new SelectList(db.Foups, "FoupID", "Name");
            ViewBag.Wafer = db.Wafers.Find(id);
            
            return View();
        }
        //================================================================================
        //
        // POST: /Transaction/Create
        [HttpPost]
        public ActionResult Create(Transaction transaction,Wafer wafer, int id)
        {
            wafer = db.Wafers.Find(id);
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                switch (transaction.TransactionTypeID)
                {
                    case 1:     // ISSUE to  FOUP
                        {
                            wafer.Status = "ISSUED TO FOUP";
                            wafer.FoupID = transaction.FoupID;
                            wafer.ContainerSlot = transaction.Slot;
                            break;
                        }
                    case 2:     // RETURN to HOMEBOAT
                        {
                            wafer.Status = "AVAILABLE";
                            wafer.FoupID = null;
                            break;
                        }
                    case 3:     // Missing:  
                        {
                            wafer.Status = "MISSING";
                            wafer.FoupID = null;
                            break;
                        }
                    case 4:     // SCRAPPED - take it out of CONTAINER
                        {
                            wafer.Status = "SCRAPPED";
                            wafer.FoupID = null;
                            break;
                        }
                    case 5:     // SHIPPED (W/ETR) - take it out of the Boat
                        {
                            wafer.Status = "SHIPPED W/ETR";
                            wafer.FoupID = null;
                            break;
                        }
                    case 6:     //ARCHIVED -Stored in Arch.Container in Racks T1-T11
                        {       //Boat will be the same name
                            wafer.Status = "ARCHIVED";
                            wafer.FoupID = null;
                            break;
                        }
                    default: 
                        break;
                }
                transaction.WaferID = id;
                transaction.Wafer = null;   
                transaction.CreatedBy = Uin;
                transaction.CreatedOn = DateTime.Now;
                transaction.ModifiedBy = Uin;
                transaction.ModifiedOn = DateTime.Now;
 
                db.Transactions.Add(transaction);
                db.SaveChanges();

                db.Entry(wafer).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index", "WaferLot");
            }

            return View(transaction);
        }

        //================================================================================

        public ActionResult ReturnTransaction(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "Name");
            ViewBag.WaferID = new SelectList(db.Wafers, "WaferID", "Name");
            return View(transaction);
        }

        //================================================================================
        //
        // POST: /Transaction/ReturnTransaction

        [HttpPost]
        public ActionResult ReturnTransaction(Transaction transaction)
        {
            var Uin = User.Identity.Name.Substring(3);

            if (ModelState.IsValid)
            {
                transaction.CreatedBy = Uin;
                transaction.CreatedOn = DateTime.Now;
                transaction.ModifiedBy = Uin;
                transaction.ModifiedOn = DateTime.Now;
                transaction.Wafer.Status = "AVAILABLE";
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "Note", transaction.TransactionTypeID);
            ViewBag.FoupID = new SelectList(db.Foups, "FoupID", "Name", transaction.FoupID);
            ViewBag.WaferID = new SelectList(db.Wafers, "WaferID", "Name", transaction.WaferID);
            return View(transaction);
        }

        //================================================================================
        //
        // GET: /Transaction/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "Note", transaction.TransactionTypeID);
            ViewBag.FoupID = new SelectList(db.Foups, "FoupID", "Name", transaction.FoupID);
            ViewBag.WaferID = new SelectList(db.Wafers, "WaferID", "Name", transaction.WaferID);
            return View(transaction);
        }

        //================================================================================
        //
        // POST: /Transaction/Edit/5

        [HttpPost]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "Note", transaction.TransactionTypeID);
            ViewBag.FoupID = new SelectList(db.Foups, "FoupID", "Name", transaction.FoupID);
            ViewBag.WaferID = new SelectList(db.Wafers, "WaferID", "Name", transaction.WaferID);
            return View(transaction);
        }

        //================================================================================
        //
        // GET: /Transaction/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //================================================================================
        //
        // POST: /Transaction/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //================================================================================

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}