using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.DTO.Weather;

//https://www.youtube.com/watch?v=Tt5zIKVMMbs&t=45s

namespace WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

public class CachedOpenWeatherMapService : IWeatherService
{
    private readonly IWeatherService _decorated;
    //private readonly IMemoryCache _memoryCache;
    private readonly IDistributedCache _distributedCache;

    public CachedOpenWeatherMapService(IWeatherService decorated, IDistributedCache distributedCache)
    {
        _decorated = decorated;
        //_memoryCache = memoryCache;
        _distributedCache = distributedCache;
    }

    public async Task<WeatherModel> GetWeather(WeatherForCreationDTO weatherForCreationDTO, CancellationToken cancellationToken = default)
    {
        string key = $"weather-{weatherForCreationDTO.Longitude}-{weatherForCreationDTO.Latitude}";

        string cachedWeather = await _distributedCache.GetStringAsync(
            key,
            cancellationToken);



        WeatherModel weather;
        if (string.IsNullOrEmpty(cachedWeather))
        {
            weather = await _decorated.GetWeather(weatherForCreationDTO, cancellationToken);
            if (weather is null)
            {
                return weather;
            }

            await _distributedCache.SetStringAsync(
                key,
                JsonSerializer.Serialize<WeatherModel>(weather),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                },
                cancellationToken);

            return weather;
        }

        weather = JsonSerializer.Deserialize<WeatherModel>(cachedWeather);

        return weather;
    }
}