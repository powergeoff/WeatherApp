using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.DTO.Weather;

namespace WeatherApp.Core.Domain.ExternalServices;
public interface IWeatherService
{
    Task<WeatherModel> GetWeather();
    Task<WeatherModel> GetWeather(WeatherForCreationDTO weatherForCreationDTO, CancellationToken cancellationToken = default);
}
