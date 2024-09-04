using GestaoIptv.Api.Entities;

namespace GestaoIptv.Api.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<Users>> FindAllUsersAsync();
    Task<IEnumerable<Users>> FindUsersByUsername(string name);
        
}
