namespace CleanArchitecture.Domain.Events;

public class InvoiceItemCreatedEvent : BaseEvent
{
    public InvoiceItemCreatedEvent(InvoiceItem item)
    {
        Item = item;
    }

    public InvoiceItem Item { get; }
}
