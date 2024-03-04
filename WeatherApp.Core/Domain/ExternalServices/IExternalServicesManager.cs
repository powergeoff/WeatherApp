using WeatherApp.Core.ExternalServices;

namespace WeatherApp.Core.Domain.ExternalServices;

public interface IExternalServicesManager
{
    IWeatherService WeatherService { get; }
}
