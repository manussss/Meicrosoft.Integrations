namespace Meicrosoft.Integrations.Domain.OrdersAggregate;

public class Invoice : Entity
{
    public Guid OrderId { get; }
    public decimal TotalValue { get; private set; }
    public EInvoiceStatus Status { get; private set; }

    public Invoice(Guid orderId, decimal totalValue)
    {
        OrderId = orderId;
        TotalValue = totalValue;
        Status = EInvoiceStatus.Unpaid;
    }

    public void UpdateStatus(EInvoiceStatus status)
    {
        Status = status;
    }
}