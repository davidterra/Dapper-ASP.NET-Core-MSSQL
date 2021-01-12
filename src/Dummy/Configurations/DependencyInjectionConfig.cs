using Dummy.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services )
        {
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}