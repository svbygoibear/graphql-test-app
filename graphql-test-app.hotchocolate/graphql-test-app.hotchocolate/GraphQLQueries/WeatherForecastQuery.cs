using graphql_test_app.hotchocolate.IService;

namespace graphql_test_app.hotchocolate.Models
{
    [ExtendObjectType(Name = "Query")]
    public class WeatherForecastQuery
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastQuery(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public List<WeatherForecast> WeatherForecasts => _weatherForecastService.GetForecasts();
    }
}
