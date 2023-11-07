using System.Net;
using MicroShop.Core.Models.Exceptions;
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
            ApplicationRequest.IsSuccessful = false;
            ApplicationRequest.Exception = exception;
            ApplicationRequest.StatusCode = HttpStatusCode.InternalServerError;
        }

        protected void SetException(RequestException requestException)
        {
            ApplicationRequest.IsSuccessful = false;
            ApplicationRequest.Exception = requestException;
            ApplicationRequest.StatusCode = requestException.Error.HttpStatusCode;
        }
    }
}
