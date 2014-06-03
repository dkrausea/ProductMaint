using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MvcMovie.Models.Mapping;

namespace MvcMovie.Models
{
    public partial class MOVIES_5657cebd144f45ea854ec6dbb73a6906Context : DbContext
    {
        static MOVIES_5657cebd144f45ea854ec6dbb73a6906Context()
        {
            Database.SetInitializer<MOVIES_5657cebd144f45ea854ec6dbb73a6906Context>(null);
        }

        public MOVIES_5657cebd144f45ea854ec6dbb73a6906Context()
            : base("Name=MOVIES_5657cebd144f45ea854ec6dbb73a6906Context")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieMap());
        }
    }
}
