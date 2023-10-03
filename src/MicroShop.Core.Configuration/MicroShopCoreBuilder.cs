using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Core.Configuration
{
    public class MicroShopCoreBuilder
    {
        public IServiceCollection Services { get; set; }

        public MicroShopCoreBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}