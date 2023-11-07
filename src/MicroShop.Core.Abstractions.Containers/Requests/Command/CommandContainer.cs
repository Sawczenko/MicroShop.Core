using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Abstractions.Containers.Requests.Command
{
    public class CommandContainer<TDbContext>
        where TDbContext : IDbContext
    {
        public TDbContext DbContext { get; }

        public CommandContainer(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
