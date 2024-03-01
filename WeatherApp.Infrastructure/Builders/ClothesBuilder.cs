using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.Builders;

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

    public ClothesBuilder(IOpenWeatherMapService openWeatherMapService)
    {
        _openWeatherMapService = openWeatherMapService;
        _layerCustomizations = new LayerCustomizations();

        _topLayersFactory = new TopLayersFactory();
        _hatLayerFactory = new HatLayerFactory();
        _handsLayerFactory = new HandsLayerFactory();
        _bottomLayerFactory = new BottomLayerFactory();
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
    public void BuildOverview() => _clothes.Overview = $"{DateTime.Now}: {_weather.City} Feels like: {_weather.FeelsLikeTemp}, Actual Temp: {_weather.Temperature}";
    public Clothes GetClothes() => _clothes;
}