namespace Meicrosoft.Integrations.Common.IntegrationEvents;

public class OrderSubmittedIntegrationEvent(
    Guid orderId,
    List<OrderItem> orderItems) : IntegrationEvent
{
    public Guid OrderId { get; set; } = orderId;
    public List<OrderItem> OrderItems { get; set; } = orderItems;
}