namespace Meicrosoft.Integrations.Common.IntegrationEvents;

public class RefundMadeIntegrationEvent(Guid orderId) : IntegrationEvent
{
    public Guid OrderId { get; set; } = orderId;
}