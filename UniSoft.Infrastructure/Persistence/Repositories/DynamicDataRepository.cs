using Dapper;
using System.Data;
using UniSoft.Domain.Entities;
using UniSoft.Domain.Interfaces;
using static Dapper.SqlMapper;


namespace UniSoft.Infrastructure.Persistence.Repositories
{
    public class DynamicDataRepository : BaseRepository, IDynamicDataRepository
    {
        private readonly IDatabaseTableRepository _databaseTableRepository;
        private readonly IDatabaseColumnRepository _databaseColumnRepository;

        public DynamicDataRepository(IDbConnection connection,
            IDatabaseTableRepository databaseTableRepository,
            IDatabaseColumnRepository databaseColumnRepository) : base(connection)
        {
            _databaseTableRepository = databaseTableRepository;
            _databaseColumnRepository = databaseColumnRepository;
        }

        public async Task<DynamicData> GetAllAsync(int tableId)
        {
            var dynamicData = new DynamicData();
            var table = await _databaseTableRepository.GetByIdAsync(tableId);
            var columns = await _databaseColumnRepository.GetByTableIdAsync(tableId);
            table.Columns = columns.ToList();

            var sql = $"SELECT * FROM \"{table.Name}\"";
            var rows = await _connection.QueryAsync<dynamic>(sql);
            dynamicData.Data = rows.AsList();
            return dynamicData;
        }

        public async Task<bool> AddAsync(int tableId, Dictionary<string, object> data)
        {
            var table = await _databaseTableRepository.GetByIdAsync(tableId);

            var columns = data.Keys.Select(col => $"\"{col}\"").ToArray();
            var values = data.Keys.Select(col => $"@{col}").ToArray();
            var sql = $"INSERT INTO \"{table.Name}\" ({string.Join(", ", columns)}) VALUES ({string.Join(", ", values)})";

            return await _connection.ExecuteAsync(sql, data) > 0;
        }

        public async Task<bool> UpdateAsync(int tableId, int id, Dictionary<string, object> data)
        {
            var table = await _databaseTableRepository.GetByIdAsync(tableId);
            var setClause = string.Join(", ", data.Keys.Select(col => $"\"{col}\" = @{col}"));

            var sql = $"UPDATE \"{table.Name}\" SET {setClause} WHERE Id = @Id";
            data["Id"] = id; // Ajouter l'ID aux paramètres
            return await _connection.ExecuteAsync(sql, data) > 0;
        }

        public async Task<bool> DeleteAsync(int tableId, int id)
        {
            var table = await _databaseTableRepository.GetByIdAsync(tableId);
            var sql = $"DELETE FROM \"{table.Name}\" WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }
    }

}