using System;
using System.Linq;
using System.Web.Mvc;
using GuestBook.Models;
using Guestbook.Models;

namespace GuestBook.Controllers
{
    public class GuestbookController : Controller
    {
        private IGuestbookRepository _repository;

        public GuestbookController()
        {
            _repository = new GuestbookRepository();
        }

        public GuestbookController(IGuestbookRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var mostRecentEntries = _repository.GetMostRecentEntries();
            return View(mostRecentEntries);
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
                _repository.AddEntry(entry);
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        public ViewResult Show(int id)
        {
            var entry = _repository.FindById(id);

            bool hasPermission = User.Identity.Name == entry.Name;

            // Using ViewData
            //ViewData["hasPermission"] = hasPermission;

            // Or using ViewBag:
            ViewBag.HasPermission = hasPermission;

            return View(entry);
        }

        public ActionResult CommentSummary()
        {
            var entries = _repository.GetCommentSummary();
            return View(entries);
        }
    }
}