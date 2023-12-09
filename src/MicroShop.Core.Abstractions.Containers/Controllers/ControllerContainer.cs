using MicroShop.Core.Interfaces.Containers.Controllers;
using MediatR;

namespace MicroShop.Core.Abstractions.Containers.Controllers
{
    public class ControllerContainer : IControllerContainer
    {
        public IMediator Mediator { get; }

        public ControllerContainer(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
