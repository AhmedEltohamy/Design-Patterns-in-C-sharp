using Decorator.Entities;
using Decorator.IServices;

namespace Decorator.Decorators;

public abstract class WeatherServiceDecorator : IWeatherService
{
    private readonly IWeatherService _weatherService;

    protected WeatherServiceDecorator(IWeatherService weatherService) => 
        _weatherService = weatherService;

    public virtual IEnumerable<WeatherForecast> GetWeatherForecasts() => _weatherService.GetWeatherForecasts();
}