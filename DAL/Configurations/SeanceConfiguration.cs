using DAL.Entities;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class SeanceConfiguration : IEntityTypeConfiguration<Seance>
    {
        public void Configure(EntityTypeBuilder<Seance> builder)
        {
            builder.Property(seance => seance.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(seance => seance.City)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(seance => seance.During)
                .IsRequired();

            builder.Property(seance => seance.DataTime)
                .IsRequired();

            builder.Property(seance => seance.PlaceCount)
                .IsRequired();

            new SeanceSeeder().Seed(builder);
        }
    }
}