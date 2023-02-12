using MicroShop.Core.Interfaces.Requests.Managers;
using MediatR;

namespace MicroShop.Core.Interfaces.RequestHandlers.Managers
{
    public interface IManagerHandler<TManager> : IRequestHandler<TManager>
    where TManager : IManager
    { }

    public interface IManagerHandler<TManager, TResponse> : IRequestHandler<TManager, TResponse>
        where TManager : IManager<TResponse>
    { }
}
