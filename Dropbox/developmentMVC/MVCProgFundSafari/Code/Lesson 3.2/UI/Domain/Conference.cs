using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeCampServerLite.UI.Domain
{
    public class Conference
    {
        private List<Session> _sessions = new List<Session>();
        private List<Attendee> _attendees = new List<Attendee>();
        private List<Fees> _fees = new List<Fees>();

        public Conference(string name)
        {
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int AttendeeCount { get; private set; }
        public int SessionCount { get; private set; }

        public IEnumerable<Session> Sessions
        {
            get
            {
                return _sessions;
            }
            private set
            {
                _sessions = new List<Session>(value);
            }
        }

        public IEnumerable<Attendee> Attendees
        {
            get
            {
                return _attendees;
            }
            private set
            {
                _attendees = new List<Attendee>(value);
            }
        }

        public void AddSession(Session session)
        {
            _sessions.Add(session);
            ++SessionCount;
        }

        public Attendee Register(string firstName, string lastName)
        {
            var attendee = new Attendee(firstName, lastName);
            _attendees.Add(attendee);
            ++AttendeeCount;
            return attendee;
        }

        public Attendee FindAttendee(Guid attendeeId)
        {
            return Attendees.FirstOrDefault(a => a.Id == attendeeId);
        }

        public void ChangeName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (name == string.Empty)
                throw new ArgumentOutOfRangeException("name", "Must be a non-empty string.");

            Name = name;
        }
    }
}