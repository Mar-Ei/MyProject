using Microsoft.AspNetCore.Mvc;

namespace мед.журнал.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<string> Summaries = new()
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public List<string> Get()
    {
      return Summaries;
    }
    public IActionResult Add(string name)
    {
        Summaries.Add(name);
        return Ok();
    }
    public IActionResult Delete(int index)
    {
        Summaries.RemoveAt(index);
        return Ok();
    }
    public IActionResult Update (int index, string name)
    {
        if (index<0 || index>=Summaries.Count)
        {
            return BadRequest("Такой индекс неверный");
        }
        Summaries[index] = name;
        return Ok();
    }
}
