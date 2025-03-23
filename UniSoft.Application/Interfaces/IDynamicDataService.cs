using UniSoft.Application.DTOs;

namespace UniSoft.Application.Interfaces
{
    public interface IDynamicDataService : IBaseService
    {
        Task<DynamicDataDto> GetAllAsync(int tableId);
    }
    
}