using MicroShop.Core.Models.Requests;
using Microsoft.Extensions.Logging;
using MediatR;

namespace MicroShop.Core.Behaviours.Pipelines.Requests
{
    internal class RequestLoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : RequestResultBase
        
    {
        private readonly ILogger<RequestLoggingPipeline<TRequest, TResponse>> _logger;

        public RequestLoggingPipeline(ILogger<RequestLoggingPipeline<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;

            _logger.LogInformation("Starting request {@RequestName}, {@DateTime}", requestName, DateTime.UtcNow);

            var result = await next();

            if (result.IsFailure)
            {
                _logger.LogError("Request {@RequestName} failed with error {@Error}, {@DateTime}", requestName, result.Error, DateTime.UtcNow);
            }

            _logger.LogInformation("Completed request {@RequestName}, {@DateTime}", requestName, DateTime.UtcNow);

            return result;
        }
    }
}
