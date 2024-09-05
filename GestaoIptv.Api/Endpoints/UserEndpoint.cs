using GestaoIptv.Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GestaoIptv.Api.Endpoints;

public static class UserEndpoint
{
    public static void MapperUser(this WebApplication app) 
    {
        app.MapGet("v1/users", GetAllUsersAsync).WithOpenApi();
        app.MapGet("v1/users/username", GetUsersByUsername).WithOpenApi();
        app.MapGet("v1/user/email", GetUsersByUsername).WithOpenApi();
    }
    public static async Task<IResult> GetAllUsersAsync([FromServices] IUserServices services) 
    {
          return Results.Ok(await services.FindAllUsersAsync());
    }

    public static async Task<IResult> GetUsersByUsername([FromServices] IUserServices services, [FromHeader] string name)
    {
        return Results.Ok(await services.FindUsersByUsernameAsync(name));
    }

    public static async Task<IResult> GetUserByEmail([FromServices] IUserServices services, [FromHeader] string email)
    {
        return Results.Ok(await services.FindUserByEmailAsync(email));
    }
}
