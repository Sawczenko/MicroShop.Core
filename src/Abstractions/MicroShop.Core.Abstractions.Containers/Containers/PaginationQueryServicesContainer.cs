using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Core.Interfaces.Database;
using MicroShop.Core.Interfaces.Services;

namespace MicroShop.Core.Abstractions.Containers.Containers
{
    internal class PaginationQueryServicesContainer : QueryServicesContainer, IPaginationQueryServicesContainer
    {

        public IPaginationService PaginationService { get; set; }

        public PaginationQueryServicesContainer(IDbContext dbContext, IPaginationService paginationService) : base(dbContext)
        {
            PaginationService = paginationService;
        }

    }
}
