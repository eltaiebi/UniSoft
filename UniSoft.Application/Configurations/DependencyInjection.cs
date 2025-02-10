using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static UniSoft.Application.Interfaces.IService;
using UniSoft.Application.Services;

namespace UniSoft.Application.Configurations
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            // Injection Générique des Services
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));

            // Injection automatique des `Services` spécifiques
            var serviceAssembly = Assembly.GetExecutingAssembly();
            var serviceTypes = serviceAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.Name.EndsWith("Service")))
                .ToList();

            foreach (var serviceType in serviceTypes)
            {
                var interfaceType = serviceType.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("Service"));
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, serviceType);
                }
            }
        }
    }
}
