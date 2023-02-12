using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Core.Interfaces.Containers.Queries
{
    public interface IQueryServicesContainer
    {

        public IDbContext DbContext { get; set; }

    }
}
