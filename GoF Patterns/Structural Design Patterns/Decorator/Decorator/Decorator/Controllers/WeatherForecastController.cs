using Decorator.Entities;
using Decorator.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Decorator.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(IWeatherService weatherService) => _weatherService = weatherService;

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get() => _weatherService.GetWeatherForecasts();
}
