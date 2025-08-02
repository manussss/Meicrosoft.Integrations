namespace Meicrosoft.Integrations.Common.IntegrationEvents;

public class InvoicedOrderIntegrationEvent(
    Guid orderId,
    Invoice invoice) : IntegrationEvent
{
    public Guid OrderId { get; set; } = orderId;
    public Invoice Invoice { get; set; } = invoice;
}