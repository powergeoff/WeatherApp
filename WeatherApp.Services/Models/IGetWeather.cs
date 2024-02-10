namespace WeatherApp.Services.Models;

public interface IGetWeather
{
    Task<WeatherModel> GetWeather(); //now we are decoupled from OpenWeatherMapAPI
}