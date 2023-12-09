using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Manager
{
    public interface IManager : IManagerRoot, IRequest<RequestResult> { }

    public interface IManager<TResponse> : IManagerRoot, IRequest<RequestResult<TResponse>> { }
}
