using GestaoIptv.Api.Application.Interfaces;
using GestaoIptv.Api.Application.Services;
using GestaoIptv.Api.Endpoints;
using GestaoIptv.Api.Persistence.Repositories.Interfaces;
using GestaoIptv.Api.Persistence.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapperUser();

await app.RunAsync();