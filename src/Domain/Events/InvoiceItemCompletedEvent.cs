namespace CleanArchitecture.Domain.Events;

public class InvoiceItemCompletedEvent : BaseEvent
{
    public InvoiceItemCompletedEvent(InvoiceItem item)
    {
        Item = item;
    }

    public InvoiceItem Item { get; }
}
