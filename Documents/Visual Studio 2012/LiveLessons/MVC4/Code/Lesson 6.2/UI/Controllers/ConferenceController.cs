﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCampServerLite.UI.Domain;
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
                    Id = c.Id,
                    Name = c.Name,
                    AttendeeCount = c.AttendeeCount,
                    SessionCount = c.SessionCount
                })
                .ToArray();

            return View(model);
        }

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "ConferenceNotFound")]
        public ActionResult Edit(Conference confname)
        {
            var model = new ConferenceEditModel
            {
                Id = confname.Id,
                Name = confname.Name,
                Attendees = confname.Attendees
                    .Select(a => new ConferenceEditModel.AttendeeEditModel
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Email = a.Email,
                    }).ToArray()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(ConferenceEditModel form)
        {
            var conf = _repository.Load(form.Id);

            conf.ChangeName(form.Name);

            foreach (var attendeeEditModel in form.Attendees)
            {
                var attendee = conf.FindAttendee(attendeeEditModel.Id);

                attendee.ChangeName(attendeeEditModel.FirstName, attendeeEditModel.LastName);
                attendee.Email = attendeeEditModel.Email;
            }

            return RedirectToRoute("Default", new { controller = "Conference", action = "Index" });
        }

    }
}
