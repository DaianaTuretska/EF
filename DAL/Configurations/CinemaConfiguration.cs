using DAL.Entities;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(cinema => cinema.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();


            builder.Property(cinema => cinema.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(cinema => cinema.Seance)
                .WithMany(seance => seance.Cinemas)
                .HasForeignKey(cinema => cinema.SeanceId)
                .OnDelete(DeleteBehavior.Cascade);

            new CinemaSeeder().Seed(builder);
        }
    }
}
