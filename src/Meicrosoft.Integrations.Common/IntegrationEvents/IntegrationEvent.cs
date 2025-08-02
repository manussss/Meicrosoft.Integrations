namespace Meicrosoft.Integrations.Common.IntegrationEvents;

public abstract class IntegrationEvent
{
    public Guid CorrelationId { get; }
    public DateTime CreatedAt { get; }

    public IntegrationEvent()
    {
        CorrelationId = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
}