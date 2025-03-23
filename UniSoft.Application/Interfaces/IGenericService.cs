namespace UniSoft.Application.Interfaces
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<int> AddAsync(TDto dto);
        Task<int> UpdateAsync(TDto dto);
        Task<int> DeleteAsync(int id);
    }
}