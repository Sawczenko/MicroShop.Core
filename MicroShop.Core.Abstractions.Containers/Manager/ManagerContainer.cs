using MicroShop.Core.Interfaces.Containers.Manager;
using MediatR;

namespace MicroShop.Core.Abstractions.Containers.Manager
{
    public class ManagerContainer : IManagerContainer
    {
        public IMediator Mediator { get; set; }

        public ManagerContainer(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
