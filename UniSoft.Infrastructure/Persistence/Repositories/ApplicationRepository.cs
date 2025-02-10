using Dapper;
using System.Data;
using UniSoft.Domain.Entities;
using UniSoft.Domain.Interfaces;

namespace UniSoft.Infrastructure.Persistence.Repositories
{
    //Repository pour Application
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour DatabaseTable
    public class DatabaseTableRepository : Repository<DatabaseTable>, IDatabaseTableRepository
    {
        public DatabaseTableRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour DatabaseColumn
    public class DatabaseColumnRepository : Repository<DatabaseColumn>, IDatabaseColumnRepository
    {
        public DatabaseColumnRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour MenuElement
    public class MenuElementRepository : Repository<MenuElement>, IMenuElementRepository
    {
        public MenuElementRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour Page
    public class PageRepository : Repository<Page>, IPageRepository
    {
        public PageRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour Component
    public class ComponentRepository : Repository<Component>, IComponentRepository
    {
        public ComponentRepository(IDbConnection connection) : base(connection) { }
    }
    // Repository pour Component
    public class PageComponentRepository : Repository<PageComponent>, IPageComponentRepository
    {
        public PageComponentRepository(IDbConnection connection) : base(connection) { }
    }

    // Repository pour FormComponentField
    public class FormComponentFieldRepository : Repository<FormComponentField>, IFormComponentFieldRepository
    {
        public FormComponentFieldRepository(IDbConnection connection) : base(connection) { }
    }

}
