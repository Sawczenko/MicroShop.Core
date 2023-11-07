namespace MicroShop.Core.Interfaces.Requests.Command;

public interface ICommand : IRequest {}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}