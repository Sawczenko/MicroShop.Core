using MicroShop.Core.Interfaces.Containers.Controllers;
using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Abstractions.Controllers.Controllers
{
    public abstract class MicroShopControllerBase
    {
        private readonly IControllerContainer controllerContainer;

        public MicroShopControllerBase(IControllerContainer controllerContainer) 
        {
            this.controllerContainer = controllerContainer;
        }

        public async Task<ApplicationRequest> ExecuteManager<TResponse>(IManager<TResponse> manager, CancellationToken cancellationToken)
        {
            await controllerContainer.Mediator.Send(manager, cancellationToken);
            return controllerContainer.ApplicationRequest;
        }

        public async Task<ApplicationRequest> ExecuteManager(IManager manager, CancellationToken cancellationToken)
        {
            await controllerContainer.Mediator.Send(manager, cancellationToken);
            return controllerContainer.ApplicationRequest;
        }
    }
}
