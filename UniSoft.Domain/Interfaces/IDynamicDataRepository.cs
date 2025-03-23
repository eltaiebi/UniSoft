using UniSoft.Domain.Entities;

namespace UniSoft.Domain.Interfaces
{
    public interface IDynamicDataRepository : IBaseRepository
    {
        Task<DynamicData> GetAllAsync(int tableId);
        Task<bool> AddAsync(int tableId, Dictionary<string, object> data);
        Task<bool> UpdateAsync(int tableId, int id, Dictionary<string, object> data);
        Task<bool> DeleteAsync(int tableId, int id);

    }
}