using MicroShop.Core.Interfaces.Containers.Requests.Command;
using MicroShop.Core.Interfaces.Requests.Command;
using MicroShop.Core.Interfaces.Database;
using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Abstractions.Requests.ResponseCommand
{
    public abstract class CommandHandlerBase<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        public abstract Task<RequestResult<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
    }

    public abstract class CommandHandlerBase<TCommand, TDbContext, TResponse> : ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TDbContext : IDbContext
    {
        protected TDbContext DbContext;

        protected CommandHandlerBase(ICommandContainer<TDbContext> commandContainer)
        {
            DbContext = commandContainer.DbContext;
        }

        public abstract Task<RequestResult<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}

namespace MicroShop.Core.Abstractions.Requests.Command
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public abstract Task<RequestResult> Handle(TCommand command, CancellationToken cancellationToken);
    }

    public abstract class CommandHandlerBase<TCommand, TDbContext> : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TDbContext : IDbContext
    {
        protected IDbContext DbContext;

        public CommandHandlerBase(ICommandContainer<TDbContext> commandContainer)
        {
            DbContext = commandContainer.DbContext;
        }

        public abstract Task<RequestResult> Handle(TCommand request, CancellationToken cancellationToken);
    }


}
