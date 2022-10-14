using DAL.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface ISeanceRepository : IRepository<Seance>
    {
        public Task<int> InsertAsync(Seance entity);
    }
}
