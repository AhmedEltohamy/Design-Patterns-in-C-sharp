using Decorator.Entities;

namespace Decorator.IServices;

public interface IWeatherService
{
    IEnumerable<WeatherForecast> GetWeatherForecasts();
}

