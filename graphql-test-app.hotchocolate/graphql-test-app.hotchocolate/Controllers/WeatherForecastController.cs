using graphql_test_app.hotchocolate.IService;
using graphql_test_app.hotchocolate.Models;
using Microsoft.AspNetCore.Mvc;

namespace graphql_test_app.hotchocolate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger;
        }

        [HttpGet(Name = "weatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastService.GetForecasts();
        }
    }
}