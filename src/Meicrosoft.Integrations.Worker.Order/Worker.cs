namespace Meicrosoft.Integrations.Worker.Order;

public class Worker(
    ILogger<Worker> logger,
    IPublishEndpoint publishEndpoint) : BackgroundService, IConsumer<OrderSubmittedIntegrationEvent>
{
    private const string ClassName = nameof(Worker);

    public async Task Consume(ConsumeContext<OrderSubmittedIntegrationEvent> context)
    {
        logger.LogInformation("{Class} | Starting | OrderId: {OrderId}", ClassName, context.Message.OrderId);

        //TODO update order with info
        //TODO save to database
        await publishEndpoint.Publish(new OrderCreatedIntegrationEvent(context.Message.OrderId, context.Message.OrderItems));

        logger.LogInformation("{Class} | Finishing | OrderId: {OrderId}", ClassName, context.Message.OrderId);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.CompletedTask;
    }
}
