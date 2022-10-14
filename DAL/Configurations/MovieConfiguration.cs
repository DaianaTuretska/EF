using DAL.Entities;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(movie => movie.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(movie => movie.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(movie => movie.Price)
                .IsRequired();

            builder.Property(movie => movie.SeanceTime)
                .IsRequired();

            builder.HasCheckConstraint("CK_Movies_MinPrice", "[Price] > 0");
            builder.HasCheckConstraint("CK_Movies_MinSeanceTime", "[SeanceTime] >= 0");

            builder.HasOne(movie => movie.Cinema)
                .WithMany(cinemas => cinemas.Movies)
                .HasForeignKey(movie => movie.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            new MovieSeeder().Seed(builder);
        }
    }
}
