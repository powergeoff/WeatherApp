using WeatherApp.Services.Factories;
using WeatherApp.Services.Models;
using WeatherApp.Services.Models.Layers;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.Services.Builders;

//https://softinbit.medium.com/builder-design-pattern-constructing-complex-objects-with-ease-61bce2df3135

//we could have ActiveClothes, RinkClothes, BeachClothes
public class ClothesBuilder : IClothesBuilder
{
    private Clothes _clothes = new();
    private WeatherModel _weather;
    private IOpenWeatherMapService _openWeatherMapService;
    private IHatLayerFactory _hatLayerFactory;
    private ILayerCustomizations _layerCustomizations;

    public ClothesBuilder(IOpenWeatherMapService openWeatherMapService, IHatLayerFactory hatLayerFactory, ILayerCustomizations layerCustomizations)
    {
        _openWeatherMapService = openWeatherMapService;
        _hatLayerFactory = hatLayerFactory;
        _layerCustomizations = layerCustomizations;
    }

    public async Task Initialize(double latitude, double longitude)
    {
        _weather = await _openWeatherMapService.GetWeather(latitude, longitude);
        _layerCustomizations.Weather = _weather;
        _hatLayerFactory.RegisterAllLayers(_layerCustomizations);

    }

    public void BuildGloves() => throw new System.NotImplementedException();
    public void BuildHat()
    {
        var hat = _hatLayerFactory.GetLayer();
        _clothes.Hat = hat?.ToString();
    }
    public void BuildTopLayers() => throw new System.NotImplementedException();
    public void BuildBottomLayer() => throw new System.NotImplementedException();
    public void BuildOverview() => _clothes.Overview = $"{_weather.City} Feels like: {_weather.FeelsLikeTemp}, Actual Temp: {_weather.Temperature}";
    public Clothes GetClothes() => _clothes;
}