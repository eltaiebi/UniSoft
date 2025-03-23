using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UniSoft.Application.Interfaces;
using UniSoft.Application.Services;

namespace UniSoft.Application.Configurations
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            // Injection Générique des Services
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            
            // Injection automatique des `Services` spécifiques
            var serviceAssembly = Assembly.GetExecutingAssembly();
            var serviceTypes = serviceAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.Name.EndsWith("Service")))
                .ToList();

            foreach (var serviceType in serviceTypes)
            {
                var interfaceType = serviceType.GetInterfaces().FirstOrDefault(i => 
                i.Name.EndsWith("Service") && 
                !i.Name.EndsWith("BaseService") && 
                !i.Name.EndsWith("GenericService"));

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, serviceType);
                }
            }
        }
    }
}
