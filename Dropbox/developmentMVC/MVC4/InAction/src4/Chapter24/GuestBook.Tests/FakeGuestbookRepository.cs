using System;
using System.Collections.Generic;
using GuestBook.Models;
using Guestbook.Models;
using System.Linq;

namespace Guestbook.Tests
{
    public class FakeGuestbookRepository : IGuestbookRepository
    {
        private List<GuestbookEntry> _entries = new List<GuestbookEntry>(); 

        public IList<GuestbookEntry> Entries
        {
            get { return _entries; }
        } 

        public IList<GuestbookEntry> GetMostRecentEntries()
        {
            return new List<GuestbookEntry>
            {
                new GuestbookEntry
                {
                    DateAdded = new DateTime(2011, 6, 1),
                    Id = 1,
                    Message = "Test message",
                    Name = "Jeremy"
                }
            };
        }

        public void AddEntry(GuestbookEntry entry)
        {
            _entries.Add(entry);
        }

        public GuestbookEntry FindById(int id)
        {
            return _entries.SingleOrDefault(x => x.Id == id);
        }

        public IList<CommentSummary> GetCommentSummary()
        {
            return new List<CommentSummary>
            {
                new CommentSummary
                {
                    UserName = "Jeremy", NumberOfComments = 1
                }
            };
        }
    }
}