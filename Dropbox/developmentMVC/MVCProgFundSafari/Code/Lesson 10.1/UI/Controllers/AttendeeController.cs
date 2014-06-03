using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCampServerLite.UI.Domain;
using CodeCampServerLite.UI.Infrastructure;
using CodeCampServerLite.UI.Models;

namespace CodeCampServerLite.UI.Controllers
{
    public class AttendeeController : DefaultController
    {
        private readonly IConferenceRepository _repository;

        public AttendeeController(IConferenceRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Show(Conference confname)
        {
            var attendees = confname.Attendees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            return AutoMapView<ConferenceShowModel.AttendeeModel[]>(attendees, PartialView("_Show"));
        }
    }
}
