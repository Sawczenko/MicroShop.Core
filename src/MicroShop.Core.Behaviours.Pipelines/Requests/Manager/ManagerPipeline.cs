using MicroShop.Core.Interfaces.Requests.Manager;
using System.Diagnostics;
using MediatR;

namespace MicroShop.Core.Behaviours.Pipelines.Requests.Manager
{
    public class ManagerPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IManagerRoot
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Activity activity = Activity.Current;

            activity?.Start()
                .AddTag("Manager", typeof(TRequest).Name)
                .AddEvent(new($"{typeof(TRequest).Name} - Started!"));

            var stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();
                var response = await next();

                return response;
            }
            catch (Exception exception)
            {
                activity?.AddEvent(new(exception.Message));
            }
            finally
            {
                stopwatch.Stop();

                activity?.AddEvent(new(typeof(TRequest).Name + $" - Ended! Duration: {stopwatch.ElapsedMilliseconds} ms."));
            }

            return default;
        }
    }
}
