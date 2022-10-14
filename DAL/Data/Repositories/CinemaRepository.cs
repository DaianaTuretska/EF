using DAL.Entities;
using DAL.Exceptions;
using DAL.Interfaces.Repositories;
using DAL.Pagination;
using DAL.Parameters;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Repositories
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(Context context) : base(context) { }

        public override async Task<IEnumerable<Cinema>> GetAsync() => await table.Include(s => s.Seance).ToListAsync();

        public override async Task<Cinema> GetByIdAsync(int id)
        {
            return await table.Include(s => s.Seance).FirstOrDefaultAsync(s => s.Id == id) ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMeassage(id));
        }

        public async Task<PagedList<Cinema>> GetAsync(CinemaParameters parameters)
        {
            IQueryable<Cinema> source = table.Include(s => s.Seance);

            SearchByName(ref source, parameters.Name);
            SearchByCity(ref source, parameters.City);

            return await PagedList<Cinema>.ToPagedListAsync(source, parameters.PageNumber, parameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Cinema> cinemas, string name)
        {
            if (!cinemas.Any() || string.IsNullOrEmpty(name))
                return;

            cinemas = cinemas.Where(s => s.Name.ToLower().Contains(name.Trim().ToLower()));
        }

        private void SearchByCity(ref IQueryable<Cinema> cinemas, string city)
        {
            if (!cinemas.Any() || string.IsNullOrEmpty(city))
                return;

            cinemas = cinemas.Where(s => s.Seance.City.ToLower().Contains(city.Trim().ToLower()));
        }
    }
}
