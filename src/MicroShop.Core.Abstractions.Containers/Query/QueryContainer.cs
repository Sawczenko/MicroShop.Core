using MicroShop.Core.Interfaces.Containers.Query;
using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Abstractions.Containers.Query
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
