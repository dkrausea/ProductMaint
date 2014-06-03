using System;
using System.Linq;
using System.Web.Mvc;
using Guestbook.Models;


namespace GuestBook.Controllers
{
    public class GuestbookController : Controller
    {
        GuestbookContext _db = new GuestbookContext();

        public ActionResult CommentSummary()
        {
            var entries = from entry in _db.Entries
                          group entry by entry.Name
                              into groupedByName
                              orderby groupedByName.Count() descending
                              select new CommentSummary
                              {
                                  NumberOfComments = groupedByName.Count(),
                                  UserName = groupedByName.Key
                              };
            return View(entries.ToList());
        }
        
        public ViewResult Show(int id)
        {
            var entry = _db.Entries.Find(id);

            bool hasPermission = User.Identity.Name == entry.Name;

            // Using ViewData
            ViewData["hasPermission"] = hasPermission;

            // Or using ViewBag:
            //ViewBag.HasPermission = hasPermission;

            return View(entry);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            if (ModelState.IsValid)
            { 
                entry.DateAdded = DateTime.UtcNow;

                _db.Entries.Add(entry);
                _db.SaveChanges();
                //return Content("New entry successfully added.");
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        public ActionResult Index()
        {
            var mostRecentEntries = (from entry in _db.Entries
                                     orderby entry.DateAdded descending
                                     select entry).Take(20);

            var model = mostRecentEntries.ToList();
            return View(model);
        }
    }
}