using graphql_test_app.hotchocolate.Models;

namespace graphql_test_app.hotchocolate.IService
{
    public interface IWeatherForecastService
    {
        List<WeatherForecast> GetForecasts();
    }
}
