using MicroShop.Core.Behaviours.Pipelines.Base;
using MicroShop.Core.Interfaces.Requests;
using MicroShop.Core.Models.Exceptions;
using MicroShop.Core.Models.Requests;
using System.Diagnostics;
using MediatR;

namespace MicroShop.Core.Behaviours.Pipelines.Requests.SubRequest
{
    internal class SubRequestPipeline<TRequest, TResponse> : ApplicationPipelineBase, IPipelineBehavior<TRequest, TResponse>
        where TRequest : ISubRequest
    {
        public SubRequestPipeline(ApplicationRequest applicationRequest) 
            : base(applicationRequest) { }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Activity activity = Activity.Current;

            activity?.AddEvent(new(typeof(TRequest).Name + " - Started!"));

            var stopwatch = Stopwatch.StartNew();

            try
            {
                var response = await next();

                return response;
            }
            finally
            {
                stopwatch.Stop();

                activity?.AddEvent(new(typeof(TRequest).Name + $" - Ended! Duration: {stopwatch.ElapsedMilliseconds} ms."));
            }
        }
    }
}
