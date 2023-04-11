using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Invoices.EventHandlers;

public class InvoiceCompletedEventHandler : INotificationHandler<InvoiceItemCompletedEvent>
{
    private readonly ILogger<InvoiceCompletedEventHandler> _logger;

    public InvoiceCompletedEventHandler(ILogger<InvoiceCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(InvoiceItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
