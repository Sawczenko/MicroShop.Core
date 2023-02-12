using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MicroShop.Catalog.Application.Pipelines
{
    public static class ServicesRegistration
    {
        public static void AddPaginationPipeline(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PaginationPipeline<,>));
        }
    }
}
