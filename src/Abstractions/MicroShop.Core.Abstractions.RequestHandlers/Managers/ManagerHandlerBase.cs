using MicroShop.Core.Interfaces.RequestHandlers.Managers;
using MicroShop.Core.Interfaces.Containers.Managers;
using MicroShop.Core.Interfaces.Requests.Managers;
using MediatR;

namespace MicroShop.Core.Abstractions.RequestHandlers.Managers
{
    public abstract class ManagerHandlerBase<TManager> : IManagerHandler<TManager>
        where TManager : IManager
    {

        protected readonly IManagerServicesContainer ManagerServicesContainer;

        protected ManagerHandlerBase(IManagerServicesContainer managerServicesContainer)
        {
            ManagerServicesContainer = managerServicesContainer;
        }

        public abstract Task<Unit> Handle(TManager request, CancellationToken cancellationToken);
    }

    public abstract class ManagerHandlerBase<TManager, TResponse> : IManagerHandler<TManager, TResponse>
        where TManager : IManager<TResponse>
    {

        protected readonly IManagerServicesContainer ManagerServicesContainer;

        protected ManagerHandlerBase(IManagerServicesContainer managerServicesContainer)
        {
            ManagerServicesContainer = managerServicesContainer;
        }

        public abstract Task<TResponse> Handle(TManager request, CancellationToken cancellationToken);
    }

}
