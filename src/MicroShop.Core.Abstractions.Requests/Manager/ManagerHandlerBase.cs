using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Interfaces.Requests.Validator;
using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Interfaces.Services.Mapper;
using MediatR;

namespace MicroShop.Core.Abstractions.Requests.Manager
{
    public abstract class ManagerHandlerBase<TManager, TResponse> : IManagerHandler<TManager, TResponse>
        where TManager : IManager<TResponse>
    {
        private readonly IMediator mediator;
        private readonly IMapperService mapperService;

        public ManagerHandlerBase(IManagerContainer container)
        {
            mediator = container.Mediator;
            mapperService = container.MapperService;
        }

        public abstract Task<TResponse> Handle(TManager manager, CancellationToken cancellationToken);

        protected async Task<TResult> Send<TResult>(IRequest<TResult> request, CancellationToken cancellationToken)
        {
            return await mediator.Send(request, cancellationToken);
        }

        protected async Task<bool> Validate(IValidator validator, CancellationToken cancellationToken)
        {
            return await mediator.Send(validator, cancellationToken);
        } 

        protected async Task<TResult> Map<TResult>(object sourceObject)
        {
            return await Task.FromResult(mapperService.Map<TResult>(sourceObject));
        }
    }
}
