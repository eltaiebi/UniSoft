using AutoMapper;
using UniSoft.Application.DTOs;
using UniSoft.Application.Interfaces;
using UniSoft.Domain.Interfaces;

namespace UniSoft.Application.Services
{
    public class DynamicDataService : BaseService, IDynamicDataService
    {
        private readonly IDynamicDataRepository _dynamicDataRepository;
        private readonly IMapper _mapper;

        public DynamicDataService(IDynamicDataRepository dynamicDataRepository, IMapper mapper) : base(mapper)
        {
            _dynamicDataRepository = dynamicDataRepository;
            _mapper = mapper;
        }

        public async Task<DynamicDataDto> GetAllAsync(int tableId)
        {
            var dynamicData = await _dynamicDataRepository.GetAllAsync(tableId);
            return _mapper.Map<DynamicDataDto>(dynamicData);
        }
    }

}


