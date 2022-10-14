using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DAL.Seeding
{

    public class SeanceSeeder : ISeeder<Seance>
    {
        private static readonly List<Seance> _seance = new()
        {
            new Seance
            {
                Id = 1,
                City = "Kyiv",
                During = "1:20",
                DataTime = 10,
                PlaceCount = 25
            },
            new Seance
            {
                Id = 2,
                City = "Chernivtsi",
                During = "1:40",
                DataTime = 15,
                PlaceCount = 50
            },
            new Seance
            {
                Id = 3,
                City = "Lviv",
                During = "2:30",
                DataTime = 20,
                PlaceCount = 25
            },
            new Seance
            {
                Id = 4,
                City = "Dnipro",
                During = "1:30",
                DataTime = 12,
                PlaceCount = 50
            }
        };

        public void Seed(EntityTypeBuilder<Seance> builder) => builder.HasData(_seance);
    }
}
