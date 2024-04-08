using MicroShop.Core.Behaviours.Pipelines.Requests.SubRequest;
using MicroShop.Core.Behaviours.Pipelines.Requests.Manager;
using MicroShop.Core.Behaviours.Pipelines.Requests;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MicroShop.Core.Behaviours.Pipelines
{
    public static class Registration
    {
        public static void AddPipelines(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestLoggingPipeline<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ManagerPipeline<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(SubRequestPipeline<,>));
        }
    }
}