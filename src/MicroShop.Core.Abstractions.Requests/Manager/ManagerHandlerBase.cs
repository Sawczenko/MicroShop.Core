using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Interfaces.Requests.Validator;
using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Interfaces.Services.Mapper;
using MicroShop.Core.Models.Requests;
using MediatR;
using MicroShop.Core.Errors;

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

        public abstract Task<RequestResult<TResponse>> Handle(TManager manager, CancellationToken cancellationToken);

        protected Task<TResult> Send<TResult>(IRequest<TResult> request, CancellationToken cancellationToken)
        {
            return mediator.Send(request, cancellationToken);
        }

        protected async Task<RequestResult> Validate(IValidator validator, CancellationToken cancellationToken)
        {
            return await mediator.Send(validator, cancellationToken);
        } 

        protected Task<TResult> Map<TResult>(object sourceObject)
        {
            return Task.FromResult(mapperService.Map<TResult>(sourceObject));
        }

        protected Task<TDestination> Map<TSource, TDestination>(TSource sourceObject)
        {
            return Task.FromResult(mapperService.Map<TSource, TDestination>(sourceObject));
        }

        protected RequestResult<TResponse> Success(TResponse response)
        {
            return RequestResult<TResponse>.Success(response);
        }


        protected RequestResult<TResponse> Failure(RequestResult requestResult)
        {
            return RequestResult<TResponse>.Failure(requestResult);
        }
    }
}
