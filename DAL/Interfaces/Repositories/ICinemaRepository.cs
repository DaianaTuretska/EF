using DAL.Entities;
using DAL.Pagination;
using DAL.Parameters;

namespace DAL.Interfaces.Repositories
{
    public interface ICinemaRepository : IRepository<Cinema>
    {
        public Task<PagedList<Cinema>> GetAsync(CinemaParameters parameters);
    }
}
