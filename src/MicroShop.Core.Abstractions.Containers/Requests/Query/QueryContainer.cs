using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Abstractions.Containers.Requests.Query
{
    public class QueryContainer<TDbContext> : IQueryContainer<TDbContext>
        where TDbContext : IDbContext
    {
        public IDbContext DbContext { get; set; }

        public QueryContainer(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
