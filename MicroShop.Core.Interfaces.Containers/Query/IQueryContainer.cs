using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Interfaces.Containers.Query
{
    public interface IQueryContainer<TDbContext>
        where TDbContext : IDbContext
    {
        public IDbContext DbContext { get; set; }
    }
}
