using MicroShop.Core.Interfaces.Containers.Manager;
using MicroShop.Core.Interfaces.Requests.Manager;
using MediatR;

namespace MicroShop.Core.Abstractions.Requests.Manager
{
    public abstract class ManagerHandlerBase<TManager, TResponse> : IManagerHandler<TManager, TResponse>
        where TManager : IManager<TResponse>
    {
        private readonly IMediator mediator;

        public ManagerHandlerBase(IManagerContainer container)
        {
            mediator = container.Mediator;
        }

        public abstract Task<TResponse> Handle(TManager request, CancellationToken cancellationToken);

        public async Task<TResponse> Send<TRequest>(TRequest request, CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
