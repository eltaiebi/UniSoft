using UniSoft.Application.DTOs;

namespace UniSoft.Application.Interfaces
{
    public interface IDynamicDataService : IBaseService
    {
        Task<DynamicDataDto> GetAllAsync(int tableId);
        Task<bool> AddAsync(int tableId, DynamicLineDto data);
        Task<bool> UpdateAsync(int tableId, int id, DynamicLineDto data);
        Task<bool> DeleteAsync(int tableId, int id);
    }
    
}