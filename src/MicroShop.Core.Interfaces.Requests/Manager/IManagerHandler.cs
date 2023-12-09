using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Manager
{
    public interface IManagerHandler<TManager> : IRequestHandler<TManager, RequestResult>
        where TManager : IManager
    { }

    public interface IManagerHandler<in TManager, TResponse> : IRequestHandler<TManager, RequestResult<TResponse>>
        where TManager : IManager<TResponse>
    { }
}
