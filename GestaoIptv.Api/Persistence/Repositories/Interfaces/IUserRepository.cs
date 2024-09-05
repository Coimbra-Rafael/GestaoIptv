using GestaoIptv.Api.Entities;

namespace GestaoIptv.Api.Persistence.Repositories.Interfaces;

public interface IUserRepository : IDisposable
{
    Task<IEnumerable<Users>> FindAllUsersAsync();
    Task<IEnumerable<Users>> FindUsersByUsernameAsync(string name);
    Task<Users> FindUserByEmailAsync(string email);
}
