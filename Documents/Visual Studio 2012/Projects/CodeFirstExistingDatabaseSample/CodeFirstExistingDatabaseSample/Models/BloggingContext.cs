using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CodeFirstExistingDatabaseSample.Models.Mapping;

namespace CodeFirstExistingDatabaseSample.Models
{
    public partial class BloggingContext : DbContext
    {
        static BloggingContext()
        {
            Database.SetInitializer<BloggingContext>(null);
        }

        public BloggingContext()
            : base("Name=BloggingContext")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new PostMap());
        }
    }
}
