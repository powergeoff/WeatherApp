using Mapster;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.Exceptions;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.DTO.Weather;

namespace WeatherApp.Core.ExternalServices;


public class WeatherService : IWeatherService
{
    private readonly IExternalServicesManager _externalServicesManager;

    public WeatherService(IExternalServicesManager externalServicesManager) => _externalServicesManager = externalServicesManager;
    public async Task<WeatherModel> GetWeather(WeatherForCreationDTO weatherForCreationDTO, CancellationToken cancellationToken = default)
    {
        var weather = await _externalServicesManager.WeatherService.GetWeather(weatherForCreationDTO, cancellationToken);

        if (weather is null)
        {
            throw new ServiceNotAvailableException("WeatherService");
        }

        return weather;
    }

    public Task<WeatherModel> GetWeather() => throw new NotImplementedException();
}