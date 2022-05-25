using project.Context;
using project.Interfaces;
using project.Services;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
var connectionString = builder.Configuration.GetConnectionString("MariaDbConnectionString");
builder.Services.AddDbContext<MariaDbContext>(options =>
{
  options.UseMySql(connectionString,
  ServerVersion.AutoDetect(connectionString));
  // mysqlOptions => mysqlOptions.ServerVersion.AutoDetect(connectionString));
});
*/
builder.Services.AddDbContext<MariaDbContext>(options =>
  {
    var connectionString = builder.Configuration.GetConnectionString("MariaDbConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
  });

builder.Services.AddScoped<IMariaDbWeatherForecastService, MariaDbWeatherForecastService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
