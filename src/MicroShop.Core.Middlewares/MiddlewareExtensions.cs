using Microsoft.AspNetCore.Builder;

namespace MicroShop.Core.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void UseMicroShopCoreErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
