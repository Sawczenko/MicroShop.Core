namespace MicroShop.Core.Interfaces.Requests.Manager
{
    public interface IManager : IManagerRoot, IRequest { }

    public interface IManager<out TResponse> : IManagerRoot, IRequest<TResponse> { }
}
