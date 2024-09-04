namespace GestaoIptv.Api.Entities.Abstractions;

public abstract class EntityBase
{
    public Guid Id { get; set; }

    protected EntityBase()
    {
        Id = Guid.NewGuid();
    }
}
