using Decorator.IServices;
using Decorator.Services;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

// Register Decorators using Scrutor Library
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.Decorate<IWeatherService>((inner, serviceProvider) => new WeatherServiceLoggingDecorator(inner, serviceProvider.GetRequiredService<ILogger<WeatherServiceLoggingDecorator>>()));
builder.Services.Decorate<IWeatherService>((inner, serviceProvider) => new WeatherServiceCachingDecorator(inner, serviceProvider.GetRequiredService<IMemoryCache>()));

// Register Decorators Built-in IoC container
/*
builder.Services.AddScoped<IWeatherService>(serviceProvider =>
{
    IWeatherService concreteService = new WeatherService();
    IWeatherService withLoggingDecorator = new WeatherServiceLoggingDecorator(concreteService, serviceProvider.GetRequiredService<ILogger<WeatherServiceLoggingDecorator>>());
    IWeatherService withCachingDecorator = new WeatherServiceCachingDecorator(withLoggingDecorator, serviceProvider.GetRequiredService<IMemoryCache>());
    return withCachingDecorator;
});
*/

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
