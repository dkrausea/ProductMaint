using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcMovie.Models.Mapping
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired();

            this.Property(t => t.Genre)
                .IsRequired();

            this.Property(t => t.Rating)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Movies");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");
            this.Property(t => t.Genre).HasColumnName("Genre");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.Stars).HasColumnName("Stars");
            this.Property(t => t.RottenTomatoes).HasColumnName("RottenTomatoes");
        }
    }
}
