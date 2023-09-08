using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Behaviours.Pipelines;
using MicroShop.Core.Models.Requests;
using System.Reflection;

namespace MicroShop.Core
{
    public static class MicroShopCore
    {
        public static void UseMicroShopCore(this IServiceCollection services, Assembly[] assemblies)
        { 
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(assemblies);
            });

            services.AddPipelines();
           
            services.AddScoped<ApplicationRequest>();
        }
    }
}