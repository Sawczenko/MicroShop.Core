using MediatR;

namespace MicroShop.Core.Interfaces.Containers.Controllers
{
    public interface IControllerContainer
    {
        public IMediator Mediator { get; }
    }
}
