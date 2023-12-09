using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Command;

public interface ICommand : IRequest<RequestResult> {}

public interface ICommand<TResponse> : IRequest<RequestResult<TResponse>>
{
    
}