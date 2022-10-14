using BLL.DTO.Requests;
using BLL.DTO.Responses;
using DAL.Pagination;
using DAL.Parameters;

namespace BLL.Interfaces.Services
{
    public interface ICinemaService
    {

        Task<IEnumerable<CinemaResponse>> GetAsync();

        Task<PagedList<CinemaResponse>> GetAsync(CinemaParameters parameters);

        Task<CinemaResponse> GetByIdAsync(int id);

        Task InsertAsync(CinemaRequest request);

        Task UpdateAsync(CinemaRequest request);

        Task DeleteAsync(int id);

    }
}
