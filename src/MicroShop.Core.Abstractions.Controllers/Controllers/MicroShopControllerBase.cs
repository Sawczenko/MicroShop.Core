using System.Net;
using MicroShop.Core.Errors;
using MicroShop.Core.Interfaces.Containers.Controllers;
using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Models.Responses;
using MicroShop.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Core.Abstractions.Controllers.Controllers
{
    public abstract class MicroShopControllerBase : ControllerBase
    {
        private readonly IControllerContainer controllerContainer;

        public MicroShopControllerBase(IControllerContainer controllerContainer) 
        {
            this.controllerContainer = controllerContainer;
        }

        protected async Task<IActionResult> ExecuteManager<TResponse>(IManager<TResponse> manager, CancellationToken cancellationToken)
        {
            var result = await controllerContainer.Mediator.Send(manager, cancellationToken);
            return CreateResponse(result);
        }

        protected async Task<IActionResult> ExecuteManager(IManager manager, CancellationToken cancellationToken)
        {
            var result = await controllerContainer.Mediator.Send(manager, cancellationToken);
            return CreateResponse(result);
        }

        private IActionResult CreateResponse(RequestResult requestResult)
        {
            if (requestResult is null)
            {
                return CreateCriticalFailure();
            }

            if (requestResult.IsFailure)
            {
                return CreateFailure(requestResult);
            }

            return StatusCode((int)requestResult.Error.HttpStatusCode, ApplicationResponse.CreateResponse());
        }

        private IActionResult CreateResponse<T>(RequestResult<T> requestResult)
        {
            if (requestResult is null)
            {
                return CreateCriticalFailure();
            }

            if (requestResult.IsFailure)
            {
                return CreateFailure(requestResult);
            }

            return StatusCode((int)requestResult.Error.HttpStatusCode, ApplicationResponse<T>.CreateResponse(requestResult.Result));
        }

        private IActionResult CreateFailure(RequestResultBase requestResult)
        {
            return StatusCode((int)requestResult.Error.HttpStatusCode, ErrorResponse.CreateResponse(requestResult.Error.Message, requestResult.Error.Value));
        }

        private IActionResult CreateCriticalFailure()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ErrorResponse.CreateResponse(Error.ERROR_UNKNOWN.Message, Error.ERROR_UNKNOWN.Value));
        }
    }
}
