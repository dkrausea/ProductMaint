using System;
using System.Collections.Generic;
using CodeCampServerLite.UI.Domain;
using Raven.Client;
using System.Linq;
using Raven.Client.Linq;

namespace CodeCampServerLite.UI.Infrastructure
{
    public interface IConferenceRepository
    {
        IEnumerable<Conference> GetAll();
        IRavenQueryable<Conference> Query();
        Conference Load(Guid id);
        Conference FindByName(string name);
    }

    public class ConferenceRepository : IConferenceRepository
    {
        private readonly IDocumentSession _documentSession;

        public ConferenceRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public Conference Load(Guid id)
        {
            return _documentSession.Load<Conference>(id);
        }

        public Conference FindByName(string name)
        {
            return _documentSession.Query<Conference>()
                .FirstOrDefault(c => c.Name == name);
        }

        public IRavenQueryable<Conference> Query()
        {
            return _documentSession.Query<Conference>();
        }

        public IEnumerable<Conference> GetAll()
        {
            return _documentSession.Query<Conference>().ToList();
        }
    }
}