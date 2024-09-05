using GestaoIptv.Api.Application.Dtos;
using GestaoIptv.Api.Application.Interfaces;
using GestaoIptv.Api.Persistence.Repositories.Interfaces;

namespace GestaoIptv.Api.Application.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _persistence;

    public UserServices(IUserRepository persistence)
    {
        _persistence = persistence;
    }

    public async Task<IEnumerable<UsersDto>> FindAllUsersAsync()
    {
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
        var user = await _persistence.FindUserByEmailAsync(email);

        return new UsersDto(user.Email, user.Username, user.State);
    }

    public async Task<IEnumerable<UsersDto>> FindUsersByUsernameAsync(string name)
    {
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
    }
}
