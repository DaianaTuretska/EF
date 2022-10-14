using DAL.Entities;
using DAL.Interfaces.Repositories;
using DAL.Pagination;
using DAL.Parameters;

namespace DAL.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(Context context) : base(context) { }

        public async Task<PagedList<Movie>> GetAsync(MovieParameters parameters)
        {
            var movies = FindByCondition(o =>
                                            (parameters.CinemaId == null || parameters.CinemaId == o.CinemaId) &&
                                            o.Price >= parameters.MinPrice &&
                                            (o.Price <= parameters.MaxPrice || parameters.MaxPrice == null) &&
                                            o.SeanceTime >= parameters.MinSeanceTime &&
                                            (o.SeanceTime <= parameters.MaxSeanceTime || parameters.MaxSeanceTime == null));

            SearchByName(ref movies, parameters.Name);

            return await PagedList<Movie>.ToPagedListAsync(movies, parameters.PageNumber, parameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Movie> movies, string name)
        {
            if (!movies.Any() || string.IsNullOrWhiteSpace(name))
                return;

            movies = movies.Where(o => o.Name.ToLower().Contains(name.Trim().ToLower()));
        }
    }
}
