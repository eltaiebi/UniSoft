using Dapper;
using System.Data;
using UniSoft.Domain.Entities;
using UniSoft.Domain.Interfaces;
using static Dapper.SqlMapper;

namespace UniSoft.Infrastructure.Persistence.Repositories
{
    //Repository pour Application
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour DatabaseTable
    public class DatabaseTableRepository : GenericRepository<DatabaseTable>, IDatabaseTableRepository
    {
        public DatabaseTableRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour DatabaseColumn
    public class DatabaseColumnRepository : GenericRepository<DatabaseColumn>, IDatabaseColumnRepository
    {
        public DatabaseColumnRepository(IDbConnection connection) : base(connection) { }

        public async Task<IEnumerable<DatabaseColumn>> GetByTableIdAsync(int tableId)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE TableId = @TableId";
            return await _connection.QueryAsync<DatabaseColumn>(sql, new { TableId = tableId });
        }
    }

    // Repository pour MenuElement
    public class MenuElementRepository : GenericRepository<MenuElement>, IMenuElementRepository
    {
        public MenuElementRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour Page
    public class PageRepository : GenericRepository<Page>, IPageRepository
    {
        public PageRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour Component
    public class ComponentRepository : GenericRepository<Component>, IComponentRepository
    {
        public ComponentRepository(IDbConnection connection) : base(connection) { }
    }
    // Repository pour Component
    public class PageComponentRepository : GenericRepository<PageComponent>, IPageComponentRepository
    {
        public PageComponentRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour FormComponentField
    public class FormComponentFieldRepository : GenericRepository<FormComponentField>, IFormComponentFieldRepository
    {
        public FormComponentFieldRepository(IDbConnection connection) : base(connection) { }
    }

}
