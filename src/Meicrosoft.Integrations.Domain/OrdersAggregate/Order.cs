namespace Meicrosoft.Integrations.Domain.OrdersAggregate;

public class Order : Entity
{
    public EOrderStatus Status { get; private set; }
    public List<OrderItem?> OrderItems { get; private set; } = [];
    public Invoice? Invoice { get; private set; }

    public Order()
    {
        Status = EOrderStatus.Submitted;
    }

    public void UpdateStatus(EOrderStatus status)
    {
        Status = status;
    }

    public void AddOrderItem(OrderItem item)
    {
        OrderItems.Add(item);
    }
}