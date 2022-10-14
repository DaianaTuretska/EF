using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeding
{
    public class CinemaSeeder : ISeeder<Cinema>
    {
        private static readonly List<Cinema> shops = new()
        {
            new Cinema
            {
                Id = 1,
                Name = "Goods",
                City = "Dnipro",
                Image = "no image",
                SeanceId = 1
            },
            new Cinema
            {
                Id = 2,
                Name = "Clothes",
                City = "Chernivtsi",
                Image = "no image",
                SeanceId = 2
            },
            new Cinema
            {
                Id = 3,
                Name = "Shoes",
                City = "lviv",
                Image = "no image",
                SeanceId = 3
            },
            new Cinema
            {
                Id = 4,
                Name = "Fruit",
                City = "Kyiv",
                Image = "no image",
                SeanceId = 4
            },
        };

        public void Seed(EntityTypeBuilder<Cinema> builder) => builder.HasData(shops);
    }
}
