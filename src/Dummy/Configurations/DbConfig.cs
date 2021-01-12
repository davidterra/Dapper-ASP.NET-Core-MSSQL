using Dummy.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Configurations
{
    public static class DbConfig
    {
        public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDb>(s => new Db(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}