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

    public SimpleClothesService(IOpenWeatherMapService openWeatherMapService)
    {
        _openWeatherMapService = openWeatherMapService;
    }

    public async Task<ClothesStart> GetClothesByCoords(double latitude, double longitude)
    {
        _openWeatherMapService.SetCoordinates(latitude, longitude);
        var weather = await _openWeatherMapService.GetWeather();
        var clothes = new ClothesStart(weather);

        return clothes;
    }

}