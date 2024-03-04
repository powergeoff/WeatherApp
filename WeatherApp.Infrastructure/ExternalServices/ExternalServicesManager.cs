using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.ExternalServices;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.ExternalServices;


public class ExternalServicesManager : IExternalServicesManager
{

    //private HttpClient _httpClient;
    //private IConfigService _config;
    private readonly Lazy<IWeatherService> _lazyWeatherService;

    public ExternalServicesManager(HttpClient httpClient, IConfigService config) //config service??
    {
        //_httpClient = httpClient;
        //_config = config;
        //every new service or collection needs one of these
        _lazyWeatherService = new Lazy<IWeatherService>(() => new OpenWeatherMapService(httpClient, config));
    }

    public IWeatherService WeatherService => _lazyWeatherService.Value;

}
