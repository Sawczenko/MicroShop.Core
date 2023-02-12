using MicroShop.Core.Interfaces.Services;

namespace MicroShop.Core.Interfaces.Containers.Queries
{
    public interface IPaginationQueryServicesContainer : IQueryServicesContainer
    {

        public IPaginationService PaginationService { get; set; }

    }
}
