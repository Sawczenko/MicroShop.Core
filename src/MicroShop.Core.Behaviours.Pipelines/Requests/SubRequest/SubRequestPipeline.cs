using MicroShop.Core.Interfaces.Requests;
using System.Diagnostics;
using MediatR;

namespace MicroShop.Core.Behaviours.Pipelines.Requests.SubRequest
{
    internal class SubRequestPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ISubRequest
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Activity activity = Activity.Current;

            activity?.AddEvent(new(typeof(TRequest).Name + " - Started!"));

            var stopwatch = new Stopwatch();

            try
            {
                stopwatch.Start();
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
