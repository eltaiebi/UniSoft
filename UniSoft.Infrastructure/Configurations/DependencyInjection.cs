using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;
using UniSoft.Domain.Interfaces;
using UniSoft.Infrastructure.Persistence.Repositories;

namespace UniSoft.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuration de Dapper
            services.ConfigureDapper(configuration);

            // Injection Générique des Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Injection automatique des `Repositories` spécifiques
            var repositoryAssembly = Assembly.GetExecutingAssembly();
            var repositoryTypes = repositoryAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.Name.EndsWith("Repository")))
                .ToList();

            foreach (var repositoryType in repositoryTypes)
            {
                var interfaceType = repositoryType.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("Repository"));
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, repositoryType);
                }
            }
        }
    }
}
