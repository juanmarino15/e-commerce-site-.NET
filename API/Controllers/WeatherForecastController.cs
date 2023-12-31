using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi =true)]

[Route("[controller]")] // this is equivalent to a route. For this case it will be GET https://localhost:5001/WeatherForecast   the "Controller" part is ignored
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger) //dependency injection
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")] //endpoint
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
