using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Core.Domain.Services;

public interface IGetWeather
{
    Task<WeatherModel> GetWeather(); //now we are decoupled from OpenWeatherMapAPI
}