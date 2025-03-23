using UniSoft.Domain.Entities;

namespace UniSoft.Domain.Interfaces
{
    // Interface pour ApplicationRepository
    public interface IApplicationRepository : IGenericRepository<Application>
    {
    }

    // Interface pour DatabaseTableRepository
    public interface IDatabaseTableRepository : IGenericRepository<DatabaseTable>
    {
    }

    // Interface pour DatabaseColumnRepository
    public interface IDatabaseColumnRepository : IGenericRepository<DatabaseColumn>
    {
        Task<IEnumerable<DatabaseColumn>> GetByTableIdAsync(int tableId);
    }

    // Interface pour MenuElementRepository
    public interface IMenuElementRepository : IGenericRepository<MenuElement>
    {
    }

    // Interface pour PageRepository
    public interface IPageRepository : IGenericRepository<Page>
    {
    }

    // Interface pour ComponentRepository
    public interface IComponentRepository : IGenericRepository<Component>
    {
    }

    // Interface pour ComponentsRepository
    public interface IPageComponentRepository : IGenericRepository<PageComponent>
    {
    }

    // Interface pour FormComponentFieldRepository
    public interface IFormComponentFieldRepository : IGenericRepository<FormComponentField>
    {
    }    

}