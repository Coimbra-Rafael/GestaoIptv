using GestaoIptv.Api.Application.Dtos;
using GestaoIptv.Api.Application.Interfaces;
using GestaoIptv.Api.Persistence.Repositories.Interfaces;

namespace GestaoIptv.Api.Application.Services;

public class UserServices(IUserRepository persistence, ILogger<UserServices> logger) : IUserServices
{
    private readonly IUserRepository _persistence = persistence;
    private readonly ILogger _logger = logger;

    public async Task<IEnumerable<UsersDto>> FindAllUsersAsync()
    {
        _logger.LogInformation("Buscando todos os usuários");
        var users = await _persistence.FindAllUsersAsync();
        var usersDto = new List<UsersDto>();
        foreach (var user in users)
        {
            usersDto.Add(new UsersDto(user.Email, user.Username, user.State));
        }
        return usersDto;
    }

    public async Task<UsersDto> FindUserByEmailAsync(string email)
    {
        _logger.LogInformation("Buscando usuário pelo email");
        var user = await _persistence.FindUserByEmailAsync(email);

        return new UsersDto(user.Email, user.Username, user.State);
    }

    public async Task<IEnumerable<UsersDto>> FindUsersByUsernameAsync(string name)
    {
        _logger.LogInformation("Buscando usuários pelo username");
        var users = await _persistence.FindUsersByUsernameAsync(name);
        var usersDto = new List<UsersDto>();
        foreach (var user in users)
        {
            usersDto.Add(new UsersDto(user.Email, user.Username, user.State));
        }
        return usersDto;
    }

    public void Dispose()
    {
        _persistence.Dispose();
        GC.SuppressFinalize(this);
    }
}
