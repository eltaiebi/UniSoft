using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UniSoft.Domain.Interfaces;

namespace UniSoft.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly IDbConnection _connection;
        protected readonly string _tableName;

        public GenericRepository(IDbConnection connection)
        {
            _connection = connection;
            _tableName = typeof(TEntity).Name; // Utilisation du nom de la classe comme nom de table
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<TEntity>(sql, new { Id = id });
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {_tableName}";
            return await _connection.QueryAsync<TEntity>(sql);
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            var sql = $"INSERT INTO {_tableName} ({GetColumns()}) VALUES ({GetValues()})";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            var sql = $"UPDATE {_tableName} SET {GetUpdateSet()} WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        private string GetColumns() => string.Join(",", typeof(TEntity).GetProperties().Select(p => p.Name));
        private string GetValues() => string.Join(",", typeof(TEntity).GetProperties().Select(p => "@" + p.Name));
        private string GetUpdateSet() => string.Join(",", typeof(TEntity).GetProperties().Where(p => p.Name != "Id").Select(p => $"{p.Name}=@{p.Name}"));
    }

}
