using System.Linq;
using System.Web.Mvc;
using GuestBook.Models;
using Guestbook.Models;

namespace GuestBook.Controllers
{
    public class GuestbookEntryMvcController : Controller
    {
        private IGuestbookRepository _repository;

        public GuestbookEntryMvcController()
        {
            _repository = new GuestbookRepository();
        }

        public GuestbookEntryMvcController(IGuestbookRepository repository)
        {
            _repository = repository;
        }

        public JsonResult Index()
        {
            var mostRecentEntries = _repository.GetMostRecentEntries();

            return Json(mostRecentEntries);
        }

        public JsonResult Show(int id)
        {
            var entry = _repository.FindById(id);

            if (entry == null)
            {
                Response.Clear();
                Response.StatusCode = 404;
                Response.End();
            }

            return Json(entry);
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry value)
        {
            if (!ModelState.IsValid)
            {
                var errors =
                    (from state in ModelState
                     where state.Value.Errors.Any()
                     select new
                     {
                         state.Key,
                         Errors = state.Value.Errors.Select(
                            error => error.ErrorMessage)
                     })
                        .ToDictionary(error => error.Key, 
                            error => error.Errors);

                return Json(errors);
            }

            _repository.AddEntry(value);

            Response.StatusCode = 200;
            Response.End();
            return new EmptyResult();
        }
    }
}