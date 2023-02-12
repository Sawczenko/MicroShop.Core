using MicroShop.Core.Interfaces.Containers.Managers;
using MicroShop.Core.Interfaces.Services;
using MicroShop.Core.Interfaces.Mediator;

namespace MicroShop.Core.Abstractions.Containers.Containers
{
    internal class ManagerServicesContainer : IManagerServicesContainer
    {
        public IMapperService MapperService { get; set; }
        public IMediatorCore Mediator { get; set; }

        public ManagerServicesContainer(IMapperService mapperService, IMediatorCore mediator)
        {
            MapperService = mapperService;
            Mediator = mediator;
        }
    }
}
