using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Behaviours.Pipelines;
using MicroShop.Core.Configuration;
using System.Reflection;

namespace MicroShop.Core
{
    public static class MicroShopCore
    {

        public static MicroShopCoreBuilder UseMicroShopCore(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(assemblies);
            });

            services.AddPipelines();

            return new MicroShopCoreBuilder(services);
        }
    }
}