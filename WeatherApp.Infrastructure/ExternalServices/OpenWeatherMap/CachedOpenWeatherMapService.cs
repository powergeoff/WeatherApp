using Microsoft.Extensions.Caching.Memory;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

public class CachedOpenWeatherMapService : IWeatherService
{
    private readonly IWeatherService _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedOpenWeatherMapService(IWeatherService decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }

    public Task<WeatherModel> GetWeather(WeatherForCreationDTO weatherForCreationDTO, CancellationToken cancellationToken = default)
    {
        string key = $"weather-{weatherForCreationDTO.Longitude}-{weatherForCreationDTO.Latitude}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return _decorated.GetWeather(weatherForCreationDTO, cancellationToken);
            });
    }
}