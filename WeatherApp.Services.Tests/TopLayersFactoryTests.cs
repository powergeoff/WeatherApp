

using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Core.Factories.Layers.TopLayers;

namespace WeatherApp.Services.Tests;

public class TopLayersFactoryTests
{

    private LayerCustomizations _customizations = new LayerCustomizations();
    TopLayersFactory _topLayersFactory = new TopLayersFactory();

    [Fact]
    public void GetLayers_ShouldReturnEmptyThenUpdateShouldReturnOne()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.TShirtMaxTemp
        };
        _customizations.Weather = weather;
        _customizations.ActivityLevel = 5;

        _topLayersFactory.RegisterAllLayers(_customizations);

        //act
        var layers = _topLayersFactory.GetLayers();

        //assert
        Assert.Empty(layers);


        //rearrange
        LayerCustomizations newCustomizations = new LayerCustomizations
        {
            ActivityLevel = -1,
            BodyTempLevel = -1,
            Weather = weather
        };
        //unregister all and reregister new ones....
        _topLayersFactory.UpdateCustomizations(newCustomizations);

        //act
        layers = _topLayersFactory.GetLayers();

        //assert
        Assert.Single(layers);
    }

    [Fact]
    public void GetLayers_ShouldReturnTshirt()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.TShirtMaxTemp - 1
        };
        _customizations.Weather = weather;

        _topLayersFactory.RegisterAllLayers(_customizations);

        //act
        var layers = _topLayersFactory.GetLayers();

        Assert.True(layers.Count == 1);
        Assert.True(layers[0].GetType() == typeof(TShirt));
    }

    [Fact]
    public void GetLayers_ShouldReturnTshirtLongSleevAndSweatshirt()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.SweatShirtMaxTemp - 1
        };
        _customizations.Weather = weather;
        _topLayersFactory.RegisterAllLayers(_customizations);

        //act
        var layers = _topLayersFactory.GetLayers();

        Assert.True(layers.Count == 2);
    }

    [Fact]
    public void GetLayers_ShouldReturnRainCoatOnly()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = 100,
            IsRaining = true
        };
        _customizations.Weather = weather;
        _topLayersFactory.RegisterAllLayers(_customizations);

        var layers = _topLayersFactory.GetLayers();

        //act
        Assert.True(layers.Count == 1);
        Assert.True(layers[0].GetType() == typeof(RainCoat));
    }

    [Fact]
    public void GetLayers_ShouldReturnSuperColdLayers()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = -100,
            IsRaining = true
        };
        _customizations.Weather = weather;
        _topLayersFactory.RegisterAllLayers(_customizations);

        var layers = _topLayersFactory.GetLayers();

        //act
        Assert.True(layers.Count == 4);
    }
}
