using MicroShop.Core.Abstractions.Containers.Manager;
using MicroShop.Core.Abstractions.Containers.Query;
using MicroShop.Core.Interfaces.Containers.Manager;
using MicroShop.Core.Interfaces.Containers.Query;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Core.Abstractions.Containers
{
    public static class Registration
    {
        public static void AddContainers(this IServiceCollection services)
        {
            services.AddScoped<IManagerContainer, ManagerContainer>();
            services.AddScoped(typeof(IQueryContainer<>), typeof(QueryContainer<>));
        }
    }
}
