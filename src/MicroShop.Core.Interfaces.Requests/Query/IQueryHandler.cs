namespace MicroShop.Core.Interfaces.Requests.Query
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    { }
}
