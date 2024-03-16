using Microsoft.EntityFrameworkCore;
using PosVideos.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<PVContext>(opt => opt
                                  .UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"))
                                  .EnableSensitiveDataLogging());

builder.Services.AddScoped<PVContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scoped = app.Services.CreateScope();
var dbContext = scoped.ServiceProvider.GetRequiredService<PVContext>();
dbContext.Database.Migrate();

app.Run();
