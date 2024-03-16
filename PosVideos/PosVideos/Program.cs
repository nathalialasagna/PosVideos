using MassTransit;
using Microsoft.EntityFrameworkCore;
using PosBooksCore.Parameters;
using PosVideos.Models;
using PosVideos.Service;
using PosVideosCore.Interfaces.Parameters;

const string MASSTRANSIT = "MassTransit";
const string SERVIDOR = "Servidor";
const string USUARIO = "Usuario";
const string SENHA = "Senha";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PVContext>(opt => opt
                                  .UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"))
                                  .EnableSensitiveDataLogging());

builder.Services.AddScoped<PVContext>();
builder.Services.AddScoped<IServiceVideoRepository, ServiceVideoRepository>();
builder.Services.AddSingleton<IParametros, Parametros>();

ConfigureMassTransit(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureMassTransit(WebApplicationBuilder webApplicationBuilder)
{
    var config = webApplicationBuilder.Configuration;
    var servidor = config.GetSection(MASSTRANSIT)[SERVIDOR] ?? string.Empty;
    var user = config.GetSection(MASSTRANSIT)[USUARIO] ?? string.Empty;
    var pass = config.GetSection(MASSTRANSIT)[SENHA] ?? string.Empty;

    webApplicationBuilder.Services.AddMassTransit(x =>
    {
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host(servidor, "/", h =>
            {
                h.Username(user);
                h.Password(pass);
            });

            cfg.ConfigureEndpoints(context);
        });
    });
}