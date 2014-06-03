using System.Linq;
using System.Web.Http;
using AutoMapper;
using CodeCampServerLite.UI.Domain;
using CodeCampServerLite.UI.Infrastructure;
using CodeCampServerLite.UI.Models;

namespace CodeCampServerLite.UI.Controllers
{
    public class AttendeeController : ApiController
    {
        private readonly IConferenceRepository _repository;

        public AttendeeController(IConferenceRepository repository)
        {
            _repository = repository;
        }

        public ConferenceShowModel.AttendeeModel[] Get(string confname)
        {
            var conference = _repository.FindByName(confname);

            var attendees = conference.Attendees
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            return Mapper.Map<Attendee[], ConferenceShowModel.AttendeeModel[]>(attendees);
        }
    }
}
