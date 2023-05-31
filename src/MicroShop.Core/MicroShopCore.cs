using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Abstractions.Containers;

namespace MicroShop.Core
{
    public static class MicroShopCore
    {
        public static void UseMicroShopCore(this IServiceCollection services)
        {
            AddContainers(services);
        }

        private static void AddContainers(IServiceCollection services)
        {
            services.AddContainers();
        }
    }
}