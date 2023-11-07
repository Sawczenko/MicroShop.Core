using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Abstractions.Containers.Requests.Query
{
    public class QueryContainer<TDbContext> : IQueryContainer<TDbContext>
        where TDbContext : IDbContext
    {
        public TDbContext DbContext { get; }

        public QueryContainer(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
