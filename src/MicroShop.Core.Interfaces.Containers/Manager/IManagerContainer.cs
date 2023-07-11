using MicroShop.Core.Interfaces.Services.Mapper;
using MediatR;

namespace MicroShop.Core.Interfaces.Containers.Manager
{
    public interface IManagerContainer
    {
        public IMediator Mediator { get; set; }

        public IMapperService MapperService { get; set; }
    }
}
