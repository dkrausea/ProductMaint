using System.Linq;
using System.Web.Http;
using CodeCampServerLite.UI.Infrastructure;
using CodeCampServerLite.UI.Models;

namespace CodeCampServerLite.UI.Controllers
{
    public class ConferencesController : ApiController
    {
        private readonly IConferenceRepository _repository;

        public ConferencesController(IConferenceRepository repository)
        {
            _repository = repository;
        }

        public ConferenceXmlModel[] Get()
        {
            var list = _repository.GetAll()
                .Select(e => new ConferenceXmlModel
                {
                    EventName = e.Name,
                    AttendeeCount = e.AttendeeCount.ToString(),
                    SessionCount = e.SessionCount.ToString()
                })
                .ToArray();

            return list;
        }
    }
}
