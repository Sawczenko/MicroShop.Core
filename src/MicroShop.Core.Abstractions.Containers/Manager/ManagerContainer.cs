using MicroShop.Core.Interfaces.Containers.Manager;
using MediatR;
using MicroShop.Core.Interfaces.Services.Mapper;

namespace MicroShop.Core.Abstractions.Containers.Manager
{
    public class ManagerContainer : IManagerContainer
    {
        public IMediator Mediator { get; set; }

        public IMapperService MapperService { get; set; }

        public ManagerContainer(IMediator mediator, IMapperService mapperService)
        {
            Mediator = mediator;
            MapperService = mapperService;
        }
    }
}
