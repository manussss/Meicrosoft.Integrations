namespace Meicrosoft.Integrations.Worker.Orchestrator.Application;

public class OrderSagaStateMachine : MassTransitStateMachine<OrderSagaState>
{
    public State Submitted { get; private set; } = null!;
    public State Created { get; private set; } = null!;
    public State Invoiced { get; private set; } = null!;
    public State Canceled { get; private set; } = null!;
    public State Refunded { get; private set; } = null!;

    public Event<OrderSubmittedIntegrationEvent> OrderSubmitted { get; private set; } = null!;
    public Event<OrderCreatedIntegrationEvent> OrderCreated { get; private set; } = null!;
    public Event<InvoicedOrderIntegrationEvent> InvoicedOrder { get; private set; } = null!;
    public Event<OrderCanceledIntegrationEvent> OrderCanceled { get; private set; } = null!;
    public Event<RefundMadeIntegrationEvent> RefundMade { get; private set; } = null!;

    //TODO add logs
    public OrderSagaStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => OrderSubmitted, x => x.CorrelateById(c => c.Message.CorrelationId));
        Event(() => OrderCreated, x => x.CorrelateById(c => c.Message.CorrelationId));
        Event(() => InvoicedOrder, x => x.CorrelateById(c => c.Message.CorrelationId));
        Event(() => OrderCanceled, x => x.CorrelateById(c => c.Message.CorrelationId));
        Event(() => RefundMade, x => x.CorrelateById(c => c.Message.CorrelationId));

        Initially(
            When(OrderSubmitted)
                .Then(ctx =>
                {
                    ctx.Saga.OrderId = ctx.Message.OrderId;
                    // logger.LogInformation("Order submitted: {ctx.Message.OrderId}");
                })
                .TransitionTo(Submitted)
        );

        During(Submitted,
            When(OrderCreated)
                // logger.LogInformation("Order created: {ctx.Message.OrderId}"))
                .TransitionTo(Created),

            When(OrderCanceled)
                // logger.LogInformation("Order canceled before creation {ctx.Message.OrderId}"))
                .TransitionTo(Canceled)
        );

        During(Created,
            When(InvoicedOrder)
                // logger.LogInformation($"Invoice generated for order {ctx.Message.OrderId}"))
                .TransitionTo(Invoiced),

            When(OrderCanceled)
                // logger.LogInformation("Order canceled {ctx.Message.OrderId}"))
                .TransitionTo(Canceled)
        );

        SetCompletedWhenFinalized();
    }
}