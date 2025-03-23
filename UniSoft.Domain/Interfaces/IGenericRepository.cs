namespace UniSoft.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(int id);
    }

}