using GestaoIptv.Api.Entities;
using GestaoIptv.Api.Persistence.Context;
using GestaoIptv.Api.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace GestaoIptv.Api.Persistence.Repositories.Services;

public class UserRepository : IUserRepository
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

    public async Task<IEnumerable<Users>> FindUsersByUsername(string name)
    {
        return await _context.Users.AsNoTracking().Where(x => x.Username.Contains(name)).ToListAsync();
    }

    public async Task<Users> FindUserByEmailAsync(string email)
    {
#pragma warning disable CS8603 // Possível retorno de referência nula.
        return await _context.Users.AsNoTracking()
            .Where(x => x.Email.Contains(email))
            .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possível retorno de referência nula.
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
