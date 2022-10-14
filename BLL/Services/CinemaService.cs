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
    public class CinemaService : ICinemaService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CinemaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CinemaResponse>> GetAsync()
        {
            var shops = await unitOfWork.CinemaRepository.GetAsync();
            return shops?.Select(mapper.Map<Cinema, CinemaResponse>);
        }

        public async Task<PagedList<CinemaResponse>> GetAsync(CinemaParameters parameters)
        {
            var productPage = await unitOfWork.CinemaRepository.GetAsync(parameters);
            return productPage?.Map(mapper.Map<Cinema, CinemaResponse>);
        }

        public async Task<CinemaResponse> GetByIdAsync(int id)
        {
            var shop = await unitOfWork.CinemaRepository.GetByIdAsync(id);
            return mapper.Map<Cinema, CinemaResponse>(shop);
        }

        public async Task InsertAsync(CinemaRequest request)
        {
            var shop = mapper.Map<CinemaRequest, Cinema>(request);
            await unitOfWork.CinemaRepository.InsertAsync(shop);
            await unitOfWork.Commit();
        }

        public async Task UpdateAsync(CinemaRequest request)
        {
            var shop = mapper.Map<CinemaRequest, Cinema>(request);
            await unitOfWork.CinemaRepository.UpdateAsync(shop);
            await unitOfWork.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.CinemaRepository.DeleteAsync(id);
            await unitOfWork.Commit();
        }

    }
}
