using Decorator.Decorators;
using Decorator.Entities;
using Decorator.IServices;
using Microsoft.Extensions.Caching.Memory;

namespace Decorator.Services;

public class WeatherServiceCachingDecorator : WeatherServiceDecorator
{
    private const string WEATER_CHACHE_KEY = "WEATER_CHACHE_KEY";

    private readonly IMemoryCache _memoryCache;

    public WeatherServiceCachingDecorator(IWeatherService weatherService, IMemoryCache memoryCache) : base(weatherService)
    {
        _memoryCache = memoryCache;
    }

    public override IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        IEnumerable<WeatherForecast> weatherForecasts;
        if (!_memoryCache.TryGetValue(WEATER_CHACHE_KEY, out weatherForecasts))
        {
            weatherForecasts = base.GetWeatherForecasts();
            _memoryCache.Set(WEATER_CHACHE_KEY, weatherForecasts, TimeSpan.FromMinutes(2));
        }
        return weatherForecasts;
    }
}