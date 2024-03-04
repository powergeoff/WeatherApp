

namespace WeatherApp.Core.Domain.ExternalServices;

public interface IExternalServicesManager
{
    IWeatherService WeatherService { get; }
}
