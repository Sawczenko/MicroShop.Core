using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Core.Interfaces.Requests.Queries;
using MediatR;

namespace MicroShop.Core.Abstractions.RequestHandlers.Queries;

public abstract class QueryHandlerBase<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    protected readonly IQueryServicesContainer QueryServicesContainer;

    protected QueryHandlerBase(IQueryServicesContainer queryServicesContainer)
    {
        QueryServicesContainer = queryServicesContainer;
    }

    public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}