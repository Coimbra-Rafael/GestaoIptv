using GestaoIptv.Api.Application.Interfaces;
using GestaoIptv.Api.Application.Services;
using GestaoIptv.Api.Endpoints;
using GestaoIptv.Api.Persistence.Context;
using GestaoIptv.Api.Persistence.Repositories.Interfaces;
using GestaoIptv.Api.Persistence.Repositories.Services;
using GestaoIptv.Api.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddDbContext<GestaoDbContext>(option => 
    option.UseNpgsql(builder.Configuration.GetConnectionString("default"))
);
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


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