using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Interfaces.Mediator;
using System.Reflection;
using MediatR;

namespace MicroShop.Core.Abstractions.Mediator
{
    public static class ServicesRegistration
    {

        public static void AddMediator(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddScoped<IMediatorCore, Mediator>();
        }

    }
}
