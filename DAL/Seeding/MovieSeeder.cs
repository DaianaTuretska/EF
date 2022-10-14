using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeding
{
    public class MovieSeeder : ISeeder<Movie>
    {
        private static readonly List<Movie> _movie = new()
        {
            new Movie
            {
                Id = 1,
                Name = "Banana",
                Description = "Fruit",
                Image = "no image",
                Price = 55,
                SeanceTime = 10,
                CinemaId = 3,
            },
            new Movie
            {
                Id = 2,
                Name = "Pants",
                Description = "Levis",
                Image = "no image",
                Price = 155,
                SeanceTime = 0,
                CinemaId = 2,
            },
            new Movie
            {
                Id = 3,
                Name = "Ledder",
                Description = "Useful",
                Image = "no image",
                Price = 35,
                SeanceTime = 0,
                CinemaId = 1,
            },
            new Movie
            {
                Id = 4,
                Name = "Bread",
                Description = "Food",
                Image = "no image",
                Price = 55,
                SeanceTime = 10,
                CinemaId = 2,
            },
        };

        public void Seed(EntityTypeBuilder<Movie> builder) => builder.HasData(_movie);
    }
}
