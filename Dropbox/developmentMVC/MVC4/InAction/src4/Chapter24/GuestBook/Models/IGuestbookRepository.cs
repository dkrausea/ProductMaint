using System.Collections.Generic;
using GuestBook.Models;

namespace Guestbook.Models
{
    public interface IGuestbookRepository
    {
        IList<GuestbookEntry> GetMostRecentEntries();
        void AddEntry(GuestbookEntry entry);
        GuestbookEntry FindById(int id);
        IList<CommentSummary> GetCommentSummary(); 
    }
}