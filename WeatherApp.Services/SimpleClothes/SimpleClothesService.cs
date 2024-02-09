using WeatherApp.Services.Models;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.Services.SimpleClothes;

public interface ISimpleClothesService
{
    Task<ClothesStart> GetClothesByCoords(double latitude, double longitude);
}

public class SimpleClothesService : ISimpleClothesService
{
    private IOpenWeatherMapService _openWeatherMapService;

    public SimpleClothesService(IOpenWeatherMapService openWeatherMapService) //relies directly on openWeatherMap
    {
        _openWeatherMapService = openWeatherMapService;
    }

    public async Task<ClothesStart> GetClothesByCoords(double latitude, double longitude)
    {
        var weather = await _openWeatherMapService.GetWeather(latitude, longitude);
        var clothes = new ClothesStart(weather);

        return clothes;
    }

}