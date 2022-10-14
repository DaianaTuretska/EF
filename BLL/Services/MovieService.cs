using AutoMapper;
using BLL.DTO.Requests;
using BLL.DTO.Responses;
using BLL.Interfaces.Services;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Pagination;
using DAL.Parameters;

namespace BLL.Services
{
    public class MovieService : IMovieService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MovieResponse>> GetAsync()
        {
            var products = await unitOfWork.MovieRepository.GetAsync();
            return products?.Select(mapper.Map<Movie, MovieResponse>);
        }

        public async Task<PagedList<MovieResponse>> GetAsync(MovieParameters parameters)
        {
            var productPage = await unitOfWork.MovieRepository.GetAsync(parameters);
            return productPage?.Map(mapper.Map<Movie, MovieResponse>);
        }

        public async Task<MovieResponse> GetByIdAsync(int id)
        {
            var product = await unitOfWork.MovieRepository.GetByIdAsync(id);
            return mapper.Map<Movie, MovieResponse>(product);
        }

        public async Task InsertAsync(MovieRequest request)
        {
            var product = mapper.Map<MovieRequest, Movie>(request);
            await unitOfWork.MovieRepository.InsertAsync(product);
            await unitOfWork.Commit();
        }

        public async Task UpdateAsync(MovieRequest request)
        {
            var product = mapper.Map<MovieRequest, Movie>(request);
            await unitOfWork.MovieRepository.UpdateAsync(product);
            await unitOfWork.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.MovieRepository.DeleteAsync(id);
            await unitOfWork.Commit();
        }
    }
}
