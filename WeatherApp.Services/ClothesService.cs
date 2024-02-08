using WeatherApp.Services.Factories;
using WeatherApp.Services.Models;
using WeatherApp.Services.Models.Layers;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.Services;

public interface IClothesService
{
    Task<Clothes> GetClothesByCoords(double latitude, double longitude);
}
public class ClothesService : IClothesService
{

    private IOpenWeatherMapService _openWeatherMapService;
    private IHatLayerFactory _hatLayerFactory;
    private ILayerCustomizations _layerCustomizations;

    public ClothesService(IOpenWeatherMapService openWeatherMapService, IHatLayerFactory hatLayerFactory, ILayerCustomizations layerCustomizations)
    {
        _openWeatherMapService = openWeatherMapService;
        _hatLayerFactory = hatLayerFactory;
        _layerCustomizations = layerCustomizations;
    }
    public async Task<Clothes> GetClothesByCoords(double latitude, double longitude)
    {
        var weather = await _openWeatherMapService.GetWeather(latitude, longitude);
        _layerCustomizations.Weather = weather;
        _hatLayerFactory.RegisterAllLayers(_layerCustomizations);

        var hat = _hatLayerFactory.GetLayer();

        var clothes = new Clothes
        {
            Hat = hat?.ToString()
        };


        return clothes;
    }


}