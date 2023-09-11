using MicroShop.Core.Interfaces.Containers.Controllers;
using MicroShop.Core.Interfaces.Requests.Manager;
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
            await controllerContainer.Mediator.Send(manager, cancellationToken);
            return GetResponse(controllerContainer.ApplicationRequest);
        }

        protected async Task<IActionResult> ExecuteManager(IManager manager, CancellationToken cancellationToken)
        {
            await controllerContainer.Mediator.Send(manager, cancellationToken);
            return GetResponse(controllerContainer.ApplicationRequest);
        }

        private IActionResult GetResponse(ApplicationRequest applicationRequest)
        {
            if (applicationRequest.IsSuccess)
            {
                return Ok(applicationRequest);
            }

            return BadRequest(applicationRequest);
        }
    }
}
