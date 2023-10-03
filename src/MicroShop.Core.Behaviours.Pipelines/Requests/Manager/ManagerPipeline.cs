using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Behaviours.Pipelines.Base;
using MicroShop.Core.Models.Requests;
using MediatR;
using System.Diagnostics;

namespace MicroShop.Core.Behaviours.Pipelines.Requests.Manager
{
    public class ManagerPipeline<TRequest, TResponse> : ApplicationPipelineBase, IPipelineBehavior<TRequest, TResponse>
        where TRequest : IManagerRoot
    {
        private readonly ApplicationRequest applicationRequest;

        public ManagerPipeline(ApplicationRequest applicationRequest) : base(applicationRequest) 
        {
            this.applicationRequest = applicationRequest;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                Activity? activity = Activity.Current;
                activity?.Start();
                activity?.AddTag("Manager", typeof(TRequest).Name);

                activity?.AddEvent(new(typeof(TRequest).Name + " - Started!"));

                applicationRequest.StartDate = DateTime.Now;

                var response = await next();

                applicationRequest.Response = response;
                applicationRequest.CompletionDate = DateTime.Now;
                TimeSpan duration = applicationRequest.CalculateDuration();
                applicationRequest.IsSuccess = true;

                activity?.AddEvent(new(typeof(TRequest).Name + $" - Ended! Duration: {duration.TotalMilliseconds} ms."));

                return response;
            }
            catch (Exception ex)
            {
                SetException(ex);
            }

            return default;
        }
    }
}
