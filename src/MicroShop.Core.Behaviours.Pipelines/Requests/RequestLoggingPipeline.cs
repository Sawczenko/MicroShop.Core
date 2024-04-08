using MicroShop.Core.Interfaces.Requests.Query;
using MicroShop.Core.Models.Requests;
using Microsoft.Extensions.Logging;
using MediatR;

namespace MicroShop.Core.Behaviours.Pipelines.Requests
{

    internal abstract class RequestLoggingPipelineBase
    {
        private readonly ILogger _logger;

        public RequestLoggingPipelineBase(ILogger logger)
        {
            _logger = logger;
        }

        protected void AddRequestStartedLog(string requestName)
        {
            _logger.LogInformation("Starting request {@RequestName}, {@DateTime}", requestName, DateTime.UtcNow);
        }

        protected void AddRequestCompletedLog(string requestName)
        {
            _logger.LogInformation("Completed request {@RequestName}, {@DateTime}", requestName, DateTime.UtcNow);
        }
    }

    internal class QueryLoggingPipeline<TRequest, TResponse> : RequestLoggingPipelineBase, IPipelineBehavior<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
        public QueryLoggingPipeline(ILogger<QueryLoggingPipeline<TRequest, TResponse>> logger) : base(logger)
        {
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            AddRequestStartedLog(requestName);

            var result = await next();

            AddRequestCompletedLog(requestName);

            return result;
        }
    }


    internal class RequestLoggingPipeline<TRequest, TResponse> : RequestLoggingPipelineBase, IPipelineBehavior<TRequest, TResponse>
        where TResponse : RequestResultBase
        
    {
        private readonly ILogger<RequestLoggingPipeline<TRequest, TResponse>> _logger;

        public RequestLoggingPipeline(ILogger<RequestLoggingPipeline<TRequest, TResponse>> logger) : base(logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;

            AddRequestStartedLog(requestName);

            var result = await next();

            if (result.IsFailure)
            {
                _logger.LogError("Request {@RequestName} failed with error {@Error}, {@DateTime}", requestName, result.Error, DateTime.UtcNow);
            }

            AddRequestCompletedLog(requestName);

            return result;
        }
    }
}
