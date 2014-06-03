using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCampServerLite.UI.Helpers;
using CodeCampServerLite.UI.Infrastructure;
using CodeCampServerLite.UI.Models;

namespace CodeCampServerLite.UI.Controllers
{
    public class ConferenceXmlController : DefaultController
    {
        private readonly IConferenceRepository _repository;

        public ConferenceXmlController(IConferenceRepository repository)
        {
            _repository = repository;
        }

        public XmlResult<ConferenceXmlModel[]> Index()
        {
            var list = _repository.GetAll()
                .Select(e => new ConferenceXmlModel
                {
                    EventName = e.Name,
                    AttendeeCount = e.AttendeeCount.ToString(),
                    SessionCount = e.SessionCount.ToString()
                })
                .ToArray();

            return Xml(list);
        }
    }
}
