namespace Guestbook.Models
{
	using System.Data.Entity;

	public class GuestbookContext : DbContext
	{
		public GuestbookContext()
			: base("Guestbook")
		{
		}

		public DbSet<GuestbookEntry> Entries { get; set; }
	}
}