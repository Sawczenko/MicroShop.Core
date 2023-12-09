using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Command;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, RequestResult>
    where TCommand : ICommand
{

}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, RequestResult<TResponse>>
    where TCommand : ICommand<TResponse>
{
    
}