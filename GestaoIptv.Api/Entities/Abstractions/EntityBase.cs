namespace GestaoIptv.Api.Entities.Abstractions;

public abstract class EntityBase : IDisposable
{
    public Guid Id { get; set; }

    protected EntityBase()
    {
        Id = Guid.NewGuid();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
