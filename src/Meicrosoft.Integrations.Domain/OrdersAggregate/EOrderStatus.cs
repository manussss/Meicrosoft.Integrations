namespace Meicrosoft.Integrations.Domain.OrdersAggregate;

public enum EOrderStatus
{
    Submitted = 0,
    Created = 1,
    Invoiced = 2,
    Canceled = 100,
    Refunded = 101
}