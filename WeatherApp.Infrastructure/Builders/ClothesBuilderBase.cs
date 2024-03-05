using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.DTO;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.Builders;

//https://softinbit.medium.com/builder-design-pattern-constructing-complex-objects-with-ease-61bce2df3135

public interface IClothesBuilder
{
    void Initialize();
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
    protected ITopLayersFactory _topLayersFactory;
    protected IHatLayerFactory _hatLayerFactory;
    protected ILayerCustomizations _layerCustomizations;
    protected IHandsLayerFactory _handsLayerFactory;
    protected IBottomLayerFactory _bottomLayerFactory;

    public ClothesBuilderBase(ILayerCustomizations layerCustomizations)
    {
        _layerCustomizations = layerCustomizations;

        _topLayersFactory = new TopLayersFactory();
        _hatLayerFactory = new HatLayerFactory();
        _handsLayerFactory = new HandsLayerFactory();
        _bottomLayerFactory = new BottomLayerFactory();
    }

    public void Initialize()
    {
        _hatLayerFactory.RegisterAllLayers(_layerCustomizations);
        _topLayersFactory.RegisterAllLayers(_layerCustomizations);
        _handsLayerFactory.RegisterAllLayers(_layerCustomizations);
        _bottomLayerFactory.RegisterAllLayers(_layerCustomizations);
    }

    public abstract void BuildGloves();
    public abstract void BuildHat();
    public abstract void BuildTopLayers();
    public abstract void BuildBottomLayer();
    public void BuildOverview() => _clothes.Overview = $"{DateTime.Now.ToLocalTime()}: {_layerCustomizations.Weather.City} Feels like: {_layerCustomizations.Weather.FeelsLikeTemp}, Actual Temp: {_layerCustomizations.Weather.Temperature}";
    public Clothes GetClothes() => _clothes;
}