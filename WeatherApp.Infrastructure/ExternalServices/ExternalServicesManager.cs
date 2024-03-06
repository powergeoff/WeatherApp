using Microsoft.Extensions.Caching.Memory;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.ExternalServices;


public class ExternalServicesManager : IExternalServicesManager
{

    private HttpClient _httpClient;
    private IConfigService _config;

    private readonly IMemoryCache _memoryCache;
    private readonly Lazy<IWeatherService> _lazyWeatherService;

    public ExternalServicesManager(HttpClient httpClient, IConfigService config, IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _httpClient = httpClient;
        _config = config;

        _lazyWeatherService = new Lazy<IWeatherService>(() =>
            new CachedOpenWeatherMapService( //implemented with decorator pattern
                new OpenWeatherMapService(_httpClient, _config), _memoryCache)
            );
    }

    public IWeatherService WeatherService => _lazyWeatherService.Value;

}
