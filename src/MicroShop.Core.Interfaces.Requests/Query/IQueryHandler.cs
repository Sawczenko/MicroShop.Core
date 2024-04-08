using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Query
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, RequestResult<TResponse>>
        where TQuery : IQuery<TResponse>
    { }
}
