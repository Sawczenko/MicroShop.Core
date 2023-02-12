using MediatR;

namespace MicroShop.Core.Interfaces.Requests.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse> { }
}
