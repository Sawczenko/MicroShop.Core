using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Interfaces.Services.Mapper;
using MediatR;

namespace MicroShop.Core.Abstractions.Containers.Requests.Manager
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
