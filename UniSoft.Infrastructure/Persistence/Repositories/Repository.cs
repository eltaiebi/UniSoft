using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UniSoft.Domain.Interfaces;

namespace UniSoft.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbConnection _connection;
        protected readonly string _tableName;

        public Repository(IDbConnection connection)
        {
            _connection = connection;
            _tableName = typeof(T).Name; // Utilisation du nom de la classe comme nom de table
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {_tableName}";
            return await _connection.QueryAsync<T>(sql);
        }

        public async Task<int> AddAsync(T entity)
        {
            var sql = $"INSERT INTO {_tableName} ({GetColumns()}) VALUES ({GetValues()})";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var sql = $"UPDATE {_tableName} SET {GetUpdateSet()} WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        private string GetColumns() => string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
        private string GetValues() => string.Join(",", typeof(T).GetProperties().Select(p => "@" + p.Name));
        private string GetUpdateSet() => string.Join(",", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"{p.Name}=@{p.Name}"));
    }

}
