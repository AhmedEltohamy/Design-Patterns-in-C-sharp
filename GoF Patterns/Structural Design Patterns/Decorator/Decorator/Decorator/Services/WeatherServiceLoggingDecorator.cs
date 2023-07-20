using Decorator.Decorators;
using Decorator.Entities;
using Decorator.IServices;

namespace Decorator.Services;

public class WeatherServiceLoggingDecorator : WeatherServiceDecorator
{
    private readonly ILogger<WeatherServiceLoggingDecorator> _logger;

    public WeatherServiceLoggingDecorator(IWeatherService weatherService, ILogger<WeatherServiceLoggingDecorator> logger) : base(weatherService)
    {
        _logger = logger;
    }

    public override IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        _logger.LogInformation("Make request to external API to get weather forecasts");
        return base.GetWeatherForecasts();
    }
}