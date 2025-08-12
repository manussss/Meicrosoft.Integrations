namespace Meicrosoft.Integrations.Domain.OrdersAggregate;

public class OrderItem : Entity
{
    public Guid OrderId { get; }
    public EProduct Product { get; }
    public decimal UnitValue { get; }
    public int Quantity { get; }
    public decimal TotalValue { get => UnitValue * Quantity; }

    public OrderItem(Guid orderId, EProduct product, decimal unitValue, int quantity)
    {
        OrderId = orderId;
        Product = product;
        UnitValue = unitValue;
        Quantity = quantity;
    }
}