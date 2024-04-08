using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.Core.Interfaces.Requests.Query;
using MicroShop.Core.Interfaces.Database;
using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Abstractions.Requests.Query
{
    public abstract class QueryHandlerBase<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
    }


    public abstract class QueryHandlerBase<TQuery, TDbContext,TResponse> : QueryHandlerBase<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TDbContext : IDbContext
    {
        protected readonly IDbContext DbContext;

        public QueryHandlerBase(IQueryContainer<TDbContext> queryContainer)
        {
            DbContext = queryContainer.DbContext;
        }
    }
}
