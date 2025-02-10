using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace UniSoft.Infrastructure.Configurations
{
    public static class DapperConfiguration
    {
        public static void ConfigureDapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(sp =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                var connection = new SqliteConnection(connectionString);
                connection.Open();
                return connection;
            });
        }
    }
}
