using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Query
{
    public interface IQuery<TResponse> : IQueryRoot, IRequest<TResponse> { }
}
