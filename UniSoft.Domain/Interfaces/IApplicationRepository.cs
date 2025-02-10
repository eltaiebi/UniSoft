using UniSoft.Domain.Entities;

namespace UniSoft.Domain.Interfaces
{
    // Interface pour ApplicationRepository
    public interface IApplicationRepository : IRepository<Application>
    {
    }

    // Interface pour DatabaseTableRepository
    public interface IDatabaseTableRepository : IRepository<DatabaseTable>
    {
    }

    // Interface pour DatabaseColumnRepository
    public interface IDatabaseColumnRepository : IRepository<DatabaseColumn>
    {
    }

    // Interface pour MenuElementRepository
    public interface IMenuElementRepository : IRepository<MenuElement>
    {
    }

    // Interface pour PageRepository
    public interface IPageRepository : IRepository<Page>
    {
    }

    // Interface pour ComponentRepository
    public interface IComponentRepository : IRepository<Component>
    {
    }

    // Interface pour ComponentsRepository
    public interface IPageComponentRepository : IRepository<PageComponent>
    {
    }

    // Interface pour FormComponentFieldRepository
    public interface IFormComponentFieldRepository : IRepository<FormComponentField>
    {
    }

}