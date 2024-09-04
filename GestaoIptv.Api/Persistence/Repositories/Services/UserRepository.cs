using GestaoIptv.Api.Entities;
using GestaoIptv.Api.Persistence.Context;
using GestaoIptv.Api.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoIptv.Api.Persistence.Repositories.Services;

public class UserRepository : IUserRepository, IDisposable
{
    private readonly GestaoDbContext _context;
    public UserRepository(GestaoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Users>> FindAllUsersAsync()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public Task<IEnumerable<Users>> FindUsersByUsername(string name)
    {
        throw new NotImplementedException();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
