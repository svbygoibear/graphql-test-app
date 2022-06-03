using graphql_test_app.hotchocolate.IService;

namespace graphql_test_app.hotchocolate.Models
{
    public class Query
    {
        private IWeatherForecastService _weatherForecastService = null;

        public Query(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public List<WeatherForecast> WeatherForecasts => _weatherForecastService.GetForecasts();
    }
}
