using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Interfaces.Containers.Requests.Command;

public interface ICommandContainer<TDbContext>
    where TDbContext : IDbContext
{
    public TDbContext DbContext { get; }
}