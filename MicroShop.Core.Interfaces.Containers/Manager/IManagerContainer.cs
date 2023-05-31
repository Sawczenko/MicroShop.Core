using MediatR;

namespace MicroShop.Core.Interfaces.Containers.Manager
{
    public interface IManagerContainer
    {
        public IMediator Mediator { get; set; }
    }
}
