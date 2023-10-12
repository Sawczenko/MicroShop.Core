using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.Core.Interfaces.Requests.Query;
using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Abstractions.Requests.Query
{
    public abstract class QueryHandlerBase<TQuery, TDbContext,TResponse> : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TDbContext : IDbContext
    {
        protected readonly IDbContext DbContext;

        public QueryHandlerBase(IQueryContainer<TDbContext> queryContainer)
        {
            DbContext = queryContainer.DbContext;
        }

        public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
