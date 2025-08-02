namespace Meicrosoft.Integrations.Common.IntegrationEvents;

public class OrderCanceledIntegrationEvent(Guid orderId) : IntegrationEvent
{
    public Guid OrderId { get; set; } = orderId;
}