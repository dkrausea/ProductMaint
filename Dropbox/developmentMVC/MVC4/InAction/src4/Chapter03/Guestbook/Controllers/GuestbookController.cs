using System;
using System.Linq;
using System.Web.Mvc;
using Guestbook.Models;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
		private GuestbookContext _db = new GuestbookContext();

        public ActionResult Index()
        {
             var mostRecentEntries = (from entry in _db.Entries
                                      orderby entry.DateAdded descending
                                      select entry).Take(20);

            var model = mostRecentEntries.ToList();
            return View(model);
        }

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
            return RedirectToAction("Index");
        }

        public ViewResult Show(int id)
        {
            var entry = _db.Entries.Find(id);

            bool hasPermission = User.Identity.Name == entry.Name;

			// Using ViewData
			//ViewData["hasPermission"] = hasPermission;
			
			// Or using ViewBag:
			ViewBag.HasPermission = hasPermission;

            return View(entry);
        }

    }
}