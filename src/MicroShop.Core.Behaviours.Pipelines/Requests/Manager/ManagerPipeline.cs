using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Behaviours.Pipelines.Base;
using MicroShop.Core.Models.Requests;
using MediatR;

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
                applicationRequest.StartDate = DateTime.Now;

                var response = await next();

                applicationRequest.Response = response;
                applicationRequest.CompletionDate = DateTime.Now;
                applicationRequest.CalculateDuration();
                applicationRequest.IsSuccess = true;

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
