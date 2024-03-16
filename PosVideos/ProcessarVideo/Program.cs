using MassTransit;
using Microsoft.EntityFrameworkCore;
using PosVideos.Models;
using PosVideosCore.Model;
using ProcessarVideo;
using ProcessarVideo.Events;
using ProcessarVideo.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        services.AddHostedService<Worker>();

        services.AddDbContext<ProcessarVideoContext>(opt => opt
                                          .UseSqlServer(configuration.GetConnectionString("SQLConnection"))
                                          .EnableSensitiveDataLogging());

        services.AddScoped<ProcessarVideoContext>();
        services.AddScoped<IProcessarVideoService, ProcessarVideoService>();

        var fila = configuration.GetSection("MassTransit")["NomeFilaPosVideos"] ?? string.Empty;
        var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
        var usuario = configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
        var senha = configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;
        services.AddHostedService<Worker>();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(servidor, "/", h =>
                {
                    h.Username(usuario);
                    h.Password(senha);
                });
                cfg.ReceiveEndpoint(fila, e =>
                {
                    e.Consumer<ZipService>(context);
                });

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<ZipService>();
        });
    })
    .Build();
var scoped = host.Services.CreateScope();

var dbContext = scoped.ServiceProvider.GetRequiredService<ProcessarVideoContext>();
dbContext.Database.Migrate();

host.Run();