using DAL.Entities;
using DAL.Interfaces.Repositories;

namespace DAL.Data.Repositories
{
    public class SeanceRepository : GenericRepository<Seance>, ISeanceRepository
    {
        Context context;

        public SeanceRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public override async Task<int> InsertAsync(Seance entity)
        {
            await table.AddAsync(entity);
            context.SaveChanges();
            return entity.Id;
        }

    }
}
