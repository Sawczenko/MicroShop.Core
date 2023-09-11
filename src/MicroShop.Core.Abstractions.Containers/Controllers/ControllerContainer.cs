using MicroShop.Core.Interfaces.Containers.Controllers;
using MicroShop.Core.Models.Requests;
using MediatR;

namespace MicroShop.Core.Abstractions.Containers.Controllers
{
    public class ControllerContainer : IControllerContainer
    {
        public IMediator Mediator { get; }

        public ApplicationRequest ApplicationRequest { get; }

        public ControllerContainer(IMediator mediator, ApplicationRequest applicationRequest)
        {
            Mediator = mediator;
            ApplicationRequest = applicationRequest;
        }
    }
}
