namespace Meicrosoft.Integrations.Worker.Invoice;

public class Worker(
    ILogger<Worker> logger,
    IPublishEndpoint publishEndpoint) : BackgroundService, IConsumer<OrderCreatedIntegrationEvent>
{
    private const string ClassName = nameof(Worker);

    public async Task Consume(ConsumeContext<OrderCreatedIntegrationEvent> context)
    {
        logger.LogInformation("{Class} | Starting | OrderId: {OrderId}", ClassName, context.Message.OrderId);

        //TODO update invoice with info
        //TODO fix total value
        var invoice = new Domain.OrdersAggregate.Invoice(context.Message.OrderId, 0);
        //TODO save to database
        await publishEndpoint.Publish(new InvoicedOrderIntegrationEvent(context.Message.OrderId, invoice));

        logger.LogInformation("{Class} | Finishing | OrderId: {OrderId}", ClassName, context.Message.OrderId);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.CompletedTask;
    }
}
