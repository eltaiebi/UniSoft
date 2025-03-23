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

        public async Task<bool> AddAsync(int tableId, DynamicLineDto data)
        {
            var dataToAdd = data.Rows.ToDictionary(
                col => col.ColumnName,
                col => (object)col.Value // On assume que la valeur est une chaîne, tu peux adapter pour les autres types
            );

            return await _dynamicDataRepository.AddAsync(tableId, dataToAdd);
        }

        public async Task<bool> UpdateAsync(int tableId, int id, DynamicLineDto data)
        {
            var dataToUpdate = data.Rows.ToDictionary(
                col => col.ColumnName,
                col => (object)col.Value // Même logique, adapter selon le type
            );

            return await _dynamicDataRepository.UpdateAsync(tableId, id, dataToUpdate);
        }

        public async Task<bool> DeleteAsync(int tableId, int id)
        {
            return await _dynamicDataRepository.DeleteAsync(tableId, id);
        }
    }

}
