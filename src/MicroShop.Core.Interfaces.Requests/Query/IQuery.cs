namespace MicroShop.Core.Interfaces.Requests.Query
{
    public interface IQuery<out TResponse> : IQueryRoot, IRequest<TResponse> { }
}
