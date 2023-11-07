using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Interfaces.Containers.Requests.Query
{
    public interface IQueryContainer<TDbContext>
        where TDbContext : IDbContext
    {
        public TDbContext DbContext { get; }
    }
}
