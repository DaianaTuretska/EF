using BLL.DTO.Requests;
using BLL.DTO.Responses;
using DAL.Pagination;
using DAL.Parameters;

namespace BLL.Interfaces.Services
{
    public interface IMovieService
    {

        Task<IEnumerable<MovieResponse>> GetAsync();

        Task<PagedList<MovieResponse>> GetAsync(MovieParameters parameters);

        Task<MovieResponse> GetByIdAsync(int id);

        Task InsertAsync(MovieRequest request);

        Task UpdateAsync(MovieRequest request);

        Task DeleteAsync(int id);

    }
}
