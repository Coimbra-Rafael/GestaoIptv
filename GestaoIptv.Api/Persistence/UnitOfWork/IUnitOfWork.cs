using Microsoft.EntityFrameworkCore.Storage;

namespace GestaoIptv.Api.Persistence.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<IDbContextTransaction> BeginTransaction();
    Task<bool> CommitAsync();
    Task RollbackAsync();

}
