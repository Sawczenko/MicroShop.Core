namespace MicroShop.Core.Interfaces.Requests.Manager
{
    public interface IManagerHandler<TManager> : IRequestHandler<TManager>
        where TManager : IManager
    { }

    public interface IManagerHandler<in TManager, TResponse> : IRequestHandler<TManager, TResponse>
        where TManager : IManager<TResponse>
    { }
}
