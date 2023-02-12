using MicroShop.Core.Interfaces.Services;
using MicroShop.Core.Interfaces.Mediator;

namespace MicroShop.Core.Interfaces.Containers.Managers
{
    public interface IManagerServicesContainer
    {

        public IMapperService MapperService { get; set; }

        public IMediatorCore Mediator { get; set; }

    }
}
