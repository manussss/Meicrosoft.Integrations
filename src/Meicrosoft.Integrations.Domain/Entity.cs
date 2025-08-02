namespace Meicrosoft.Integrations.Domain;

public abstract class Entity
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }

    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
}