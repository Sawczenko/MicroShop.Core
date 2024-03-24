using MicroShop.Core.Models.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using MicroShop.Core.Errors;
using System.Net;

namespace MicroShop.Core.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error occurred: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorResponse()
            {
                ErrorCode = Error.ERROR_UNKNOWN,
                Message = Error.ERROR_UNKNOWN.Message
            }.ToString());
        }
    }
}
