using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Behaviours.Pipelines.Base
{
    public abstract class ApplicationPipelineBase
    {
        protected ApplicationRequest ApplicationRequest { get; }

        public ApplicationPipelineBase(ApplicationRequest applicationRequest)
        {
            ApplicationRequest = applicationRequest;
        }
        
        protected void SetException(Exception exception)
        {
            ApplicationRequest.IsSuccess = false;
            ApplicationRequest.Exception = exception;
        }
    }
}
