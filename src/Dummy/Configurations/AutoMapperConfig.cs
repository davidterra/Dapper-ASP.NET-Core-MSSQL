using AutoMapper;
using Dummy.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddMapper(this IServiceCollection services )
        {
            services.AddAutoMapper(typeof(ToViewModelMappingProfile));

            return services;
        }
    }
}