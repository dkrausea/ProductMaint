using System.Data.Entity;

namespace GuestBook.Models
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext() : base("Guestbook"){}

        public DbSet<GuestbookEntry> Entries { get; set; }
    }
}