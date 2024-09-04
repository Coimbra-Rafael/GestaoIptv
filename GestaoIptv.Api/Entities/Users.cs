using GestaoIptv.Api.Entities.Abstractions;

namespace GestaoIptv.Api.Entities;

public class Users : EntityBase
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool State { get; set; }

    public Users(string username, string password, bool state)
    {
        Username = username;
        Password = password;
        State = state;
    }
}
