
using GestaoIptv.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace GestaoIptv.Api.Persistence.UnitOfWork;

public class UnitOfWork(GestaoDbContext context) : IUnitOfWork
{
    private readonly GestaoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private IDbContextTransaction? _transaction;

    public async Task<IDbContextTransaction> BeginTransaction()
    {
        if (!await _context.Database.CanConnectAsync())
        {
            await _context.Database.OpenConnectionAsync();
        }

        if (_transaction != null)
        {
            throw new InvalidOperationException("Uma transação já está em andamento.");
        }

        _transaction = await _context.Database.BeginTransactionAsync();
        return _transaction;
    }

    public async Task<bool> CommitAsync()
    {
        try
        {
            int rowsAffected = await _context.SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
            return rowsAffected > 0;
        }
        catch (Exception)
        {
            _transaction?.Dispose();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
