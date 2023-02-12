using MicroShop.Core.Interfaces.Mediator;
using MediatR;

namespace MicroShop.Core.Abstractions.Mediator
{
    public class Mediator : IMediatorCore
    {
        private readonly IMediator mediator;

        public Mediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return mediator.CreateStream(request, cancellationToken);
        }

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
        {
            return mediator.CreateStream(request, cancellationToken);
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            return mediator.Publish(notification, cancellationToken);
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            return mediator.Publish(notification, cancellationToken);
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return mediator.Send(request, cancellationToken);
        }

        public Task<object?> Send(object request, CancellationToken cancellationToken = default)
        {
            return mediator.Send(request, cancellationToken);
        }
    }
}