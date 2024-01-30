using WeatherApp.Services.Models;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.Services;

public interface IClothesService
{
    Task<Clothes> GetClothesByCoords(double latitude, double longitude);
}

public class ClothesService : IClothesService
{
    private IOpenWeatherMapService _openWeatherMapService;

    public ClothesService(IOpenWeatherMapService openWeatherMapService) //relies directly on openWeatherMap
    {
        _openWeatherMapService = openWeatherMapService;
    }

    public async Task<Clothes> GetClothesByCoords(double latitude, double longitude)
    {
        var weather = await _openWeatherMapService.GetWeather(latitude, longitude);
        var clothes = new Clothes(weather);
        return clothes;
    }

}