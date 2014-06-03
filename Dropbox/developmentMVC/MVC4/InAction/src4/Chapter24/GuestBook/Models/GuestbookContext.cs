using System.Data.Entity;

namespace GuestBook.Models
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext() : base("GuestBook"){}

        public DbSet<GuestbookEntry> Entries { get; set; }
    }
}