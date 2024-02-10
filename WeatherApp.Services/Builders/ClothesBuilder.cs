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
    private ITopLayersFactory _topLayersFactory;
    private IHatLayerFactory _hatLayerFactory;
    private ILayerCustomizations _layerCustomizations;
    private IHandsLayerFactory _handsLayerFactory;
    private IBottomLayerFactory _bottomLayerFactory;

    public ClothesBuilder(IOpenWeatherMapService openWeatherMapService, IHandsLayerFactory handsLayerFactory, IBottomLayerFactory bottomLayerFactory, ITopLayersFactory topLayersFactory, IHatLayerFactory hatLayerFactory, ILayerCustomizations layerCustomizations)
    {
        _openWeatherMapService = openWeatherMapService;
        _layerCustomizations = layerCustomizations;

        _topLayersFactory = topLayersFactory;
        _hatLayerFactory = hatLayerFactory;
        _handsLayerFactory = handsLayerFactory;
        _bottomLayerFactory = bottomLayerFactory;
    }

    public async Task Initialize()
    {
        _weather = await _openWeatherMapService.GetWeather();
        //next cache service call by coordinates for 15 minutes or so...
        //maybe log the time it was fetched for testing
        _layerCustomizations.Weather = _weather;

        _hatLayerFactory.RegisterAllLayers(_layerCustomizations);
        _topLayersFactory.RegisterAllLayers(_layerCustomizations);
        _handsLayerFactory.RegisterAllLayers(_layerCustomizations);
        _bottomLayerFactory.RegisterAllLayers(_layerCustomizations);
    }

    public void BuildGloves()
    {
        var gloves = _handsLayerFactory.GetLayer();
        _clothes.Gloves = gloves?.ToString();
    }
    public void BuildHat()
    {
        var hat = _hatLayerFactory.GetLayer();
        _clothes.Hat = hat?.ToString();
    }
    public void BuildTopLayers()
    {
        var topLayers = _topLayersFactory.GetLayers();
        foreach (var layer in topLayers)
        {
            _clothes.TopLayers.Add(layer.ToString());
        }
    }
    public void BuildBottomLayer()
    {
        var bottom = _bottomLayerFactory.GetLayer();
        _clothes.BottomLayer = bottom.ToString(); //no null here YOU MUST WEAR PANTS OR SHORTS!
    }
    public void BuildOverview() => _clothes.Overview = $"{_weather.City} Feels like: {_weather.FeelsLikeTemp}, Actual Temp: {_weather.Temperature}";
    public Clothes GetClothes() => _clothes;
}