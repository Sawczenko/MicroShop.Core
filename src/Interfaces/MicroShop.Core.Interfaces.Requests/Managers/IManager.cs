using MediatR;

namespace MicroShop.Core.Interfaces.Requests.Managers
{
    public interface IManager : IRequest { }

    public interface IManager<TResponse> : IRequest<TResponse> { }
}
