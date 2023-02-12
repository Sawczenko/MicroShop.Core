using MicroShop.Core.Abstractions.Services.Pagination;
using MicroShop.Core.Abstractions.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Interfaces.Services;
using System.Reflection;

namespace MicroShop.Core.Abstractions.Services
{
    public static class ServicesRegistration
    {

        public static void AddServices(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddPaginationService();
            services.AddMapper(assemblies);
        }

        private static void AddPaginationService(this IServiceCollection services)
        {
            services.AddScoped<IPaginationService, PaginationService>();
        }

        private static void AddMapper(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            services.AddScoped<IMapperService, MapperService>();
        }

    }
}
