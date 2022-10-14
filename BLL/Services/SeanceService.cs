using AutoMapper;
using BLL.DTO.Requests;
using BLL.DTO.Responses;
using BLL.Interfaces.Services;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SeanceService : ISeanceService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SeanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SeanceResponse>> GetAsync()
        {
            var addresses = await unitOfWork.SeanceRepository.GetAsync();
            return addresses?.Select(mapper.Map<Seance, SeanceResponse>);
        }

        public async Task<SeanceResponse> GetByIdAsync(int id)
        {
            var address = await unitOfWork.SeanceRepository.GetByIdAsync(id);
            return mapper.Map<Seance, SeanceResponse>(address);
        }

        public async Task<int> InsertAsync(SeanceRequest request)
        {
            var address = mapper.Map<SeanceRequest, Seance>(request);
            int id = await unitOfWork.SeanceRepository.InsertAsync(address);
            await unitOfWork.Commit();
            return id;
        }

        public async Task UpdateAsync(SeanceRequest request)
        {
            var address = mapper.Map<SeanceRequest, Seance>(request);
            await unitOfWork.SeanceRepository.UpdateAsync(address);
            await unitOfWork.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.SeanceRepository.DeleteAsync(id);
            await unitOfWork.Commit();
        }
    }
}
