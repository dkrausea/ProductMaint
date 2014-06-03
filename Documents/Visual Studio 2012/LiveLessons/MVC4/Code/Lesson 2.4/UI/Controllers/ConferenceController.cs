using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCampServerLite.UI.Infrastructure;
using CodeCampServerLite.UI.Models;

namespace CodeCampServerLite.UI.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository _repository;

        public ConferenceController(IConferenceRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Conference/

        public ActionResult Index(int? minSessions)
        {
            var conferences = _repository.Query()
                .Where(c => c.SessionCount >= minSessions)
                .ToList();

            var model = conferences
                .Select(c => new ConferenceListModel
                {
                    Name = c.Name,
                    AttendeeCount = c.AttendeeCount,
                    SessionCount = c.SessionCount
                })
                .ToArray();

            return View(model);
        }

    }
}
