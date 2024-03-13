using Moq;
using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Core.RepositoryServices;

internal class MockIWeatherService
{
    public static Mock<IWeatherService> GetMock()
    {
        var mock = new Mock<IWeatherService>();
        /*
            ret.City = poco.name;
            ret.Overall = poco.weather[0].main;
            ret.Description = poco.weather[0].description;
            ret.Humidity = poco.main.humidity;
            ret.Temperature = poco.main.temp;
            ret.FeelsLikeTemp = poco.main.feels_like;
            ret.IsRaining = poco.rain?.nextHourTotal > 0;
            ret.IsSnowing = poco.snow?.nextHourTotal > 0;
            ret.WindSpeed = poco.wind.speed;
            ret.WindDirection = WeatherModel.ConvertWindDirection(poco.wind.deg);
            ret.CreatedTime = DateTime.Now.ToLocalTime();
        */
        var weatherModel = new WeatherModel()
        {
            FeelsLikeTemp = 80,
            City = "Fake City, USA",
            Overall = "Fake City is nice right now",
            CreatedTime = DateTime.Now.ToLocalTime()
        };

        mock.Setup<Task<WeatherModel>>(m => m.GetWeather(It.IsAny<WeatherForCreationDTO>(), CancellationToken.None)).Returns((WeatherForCreationDTO weatherDTO, CancellationToken token) => Task.FromResult<WeatherModel>(weatherModel));
        return mock;
    }
}