using UniSoft.Domain.Entities;

namespace UniSoft.Domain.Interfaces
{
    public interface IDynamicDataRepository : IBaseRepository
    {
        Task<DynamicData> GetAllAsync(int tableId);
    }
}