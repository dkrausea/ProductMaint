using System;
using System.Linq;
using System.Web.Mvc;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class GuestbookController : Controller
    {
        GuestbookContext _db = new GuestbookContext();
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            entry.DateAdded = DateTime.Now;

            _db.Entries.Add(entry);
            _db.SaveChanges();
            //return Content("New entry successfully added.");
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var mostRecentEntries = (from entry in _db.Entries
                                     orderby entry.DateAdded descending
                                     select entry).Take(20);

            ViewBag.Entries = mostRecentEntries.ToList();
            return View();
        }
    }
}