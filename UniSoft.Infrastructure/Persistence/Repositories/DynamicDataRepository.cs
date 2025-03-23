using Dapper;
using System.Data;
using UniSoft.Domain.Entities;
using UniSoft.Domain.Interfaces;
using static Dapper.SqlMapper;

namespace UniSoft.Infrastructure.Persistence.Repositories
{
    public class DynamicDataRepository : BaseRepository, IDynamicDataRepository
    {
        private IDatabaseTableRepository _databaseTableRepository;
        private IDatabaseColumnRepository _databaseColumnRepository;

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
            // Vérifier si la table existe
            var tableExists = await _connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@TableName",
                new { TableName = table.Name }
            );

            if (tableExists == 0)
            {
                // La table n'existe pas, on la crée
                await CreateTableAsync(table);
            }

            var sql = $"SELECT * FROM \"{table.Name}\"";
            var rows = await _connection.QueryAsync<dynamic>(sql);
            dynamicData.Data = rows.AsList();
            return dynamicData;
        }
        private async Task CreateTableAsync(DatabaseTable table)
        {
            var columnDefinitions = table.Columns
                .Where(col => !string.IsNullOrWhiteSpace(col.Name)) // Éviter les noms vides
                .Select(col =>
                {
                    var typeMapping = col.DataType;
                    var constraints = new List<string>();

                    if (col.IsPrimaryKey) constraints.Add("PRIMARY KEY");
                    if (!col.IsNullable) constraints.Add("NOT NULL");
                    if (col.IsIndexed) constraints.Add("UNIQUE");

                    return $"\"{col.Name}\" {typeMapping} {string.Join(" ", constraints)}";
                })
                .ToList(); // Éviter les erreurs de concaténation

            if (!columnDefinitions.Any())
            {
                throw new Exception($"La table '{table.Name}' n'a pas de colonnes définies.");
            }

            var createTableSql = $"CREATE TABLE \"{table.Name}\" ({string.Join(", ", columnDefinitions)})";

            Console.WriteLine($"Executing SQL: {createTableSql}"); // Debug SQL

            await _connection.ExecuteAsync(createTableSql);
        }

    }
}
