using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.DTO;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.Builders;

//https://softinbit.medium.com/builder-design-pattern-constructing-complex-objects-with-ease-61bce2df3135

public interface IClothesBuilder
{
    Task Initialize();
    void BuildGloves();
    void BuildHat();
    void BuildTopLayers();
    void BuildBottomLayer();
    void BuildOverview();
    Clothes GetClothes();
}


public abstract class ClothesBuilderBase : IClothesBuilder
{
    protected Clothes _clothes = new();
    protected WeatherModel _weather;
    private IOpenWeatherMapService _openWeatherMapService;
    protected ITopLayersFactory _topLayersFactory;
    protected IHatLayerFactory _hatLayerFactory;
    protected ILayerCustomizations _layerCustomizations;
    protected IHandsLayerFactory _handsLayerFactory;
    protected IBottomLayerFactory _bottomLayerFactory;
    //protected IClothesBuilder _clothesBuilder;
    private UserDTO _user;
    public ClothesBuilderBase(UserDTO user, IOpenWeatherMapService openWeatherMapService)
    {
        //_clothesBuilder = clothesBuilder;
        _user = user;
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
        _layerCustomizations.ActivityLevel = _user.ActivityLevel;
        _layerCustomizations.BodyTempLevel = _user.BodyTemp;
        _layerCustomizations.Weather = _weather;

        _hatLayerFactory.RegisterAllLayers(_layerCustomizations);
        _topLayersFactory.RegisterAllLayers(_layerCustomizations);
        _handsLayerFactory.RegisterAllLayers(_layerCustomizations);
        _bottomLayerFactory.RegisterAllLayers(_layerCustomizations);
    }

    public abstract void BuildGloves();
    public abstract void BuildHat();
    public abstract void BuildTopLayers();
    public abstract void BuildBottomLayer();
    public void BuildOverview() => _clothes.Overview = $"{DateTime.Now}: {_weather.City} Feels like: {_weather.FeelsLikeTemp}, Actual Temp: {_weather.Temperature}";
    public Clothes GetClothes() => _clothes;
}