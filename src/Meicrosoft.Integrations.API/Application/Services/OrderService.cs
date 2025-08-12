namespace Meicrosoft.Integrations.API.Application.Services;

public class OrderService(
    IPublishEndpoint publishEndpoint,
    ILogger<OrderService> logger) : IOrderService
{
    private const string ClassName = nameof(OrderService);
    
    public async Task CreateAsync(CreateOrderDto dto)
    {
        var order = new Order();

        logger.LogInformation("{Class} | Starting | OrderId: {OrderId}", ClassName, order.Id);

        var orderItems = dto
            .OrderItems
            .Select(oi => new OrderItem(order.Id, oi.Product, oi.UnitValue, oi.Quantity));
        order.AddOrderItem(orderItems);

        //TODO save to database

        await publishEndpoint.Publish(new OrderSubmittedIntegrationEvent(order.Id, order.OrderItems));

        logger.LogInformation("{Class} | Finishing | OrderId: {OrderId}", ClassName, order.Id);
    }
}