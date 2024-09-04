using GestaoIptv.Api.Application.Dtos;
using GestaoIptv.Api.Entities;

namespace GestaoIptv.Api.Application.Interfaces;

public interface IUserServices : IDisposable
{
    Task<IEnumerable<UsersDto>> FindAllUsersAsync();
    Task<IEnumerable<UsersDto>> FindUsersByUsername(string name);
    Task<UsersDto> FindUserByEmailAsync(string email);
}
