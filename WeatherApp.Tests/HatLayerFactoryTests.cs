

using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Core.Factories.Layers.HatLayers;

namespace WeatherApp.Services.Tests;

public class HatLayerFactoryTests
{
    private LayerCustomizations _customizations = new LayerCustomizations();
    private HatLayerFactory _hatLayersFactory = new HatLayerFactory();

    [Fact]
    public void GetLayer_ShouldReturnEmpty()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.WinterHatMaxTemp
        };
        _customizations.ActivityLevel = 5;
        _customizations.Weather = weather;

        _hatLayersFactory.RegisterAllLayers(_customizations);

        //act
        var layer = _hatLayersFactory.GetLayer();

        //assert
        Assert.True(layer == null);
    }

    [Fact]
    public void GetLayer_ShouldReturnWinterHat()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.WinterHatMaxTemp
        };
        _customizations.ActivityLevel = -2;
        _customizations.Weather = weather;

        _hatLayersFactory.RegisterAllLayers(_customizations);

        //act
        var layer = _hatLayersFactory.GetLayer();

        //assert
        Assert.True(layer.GetType() == typeof(WinterHat));
    }

    [Fact]
    public void GetLayer_ShouldReturnHeavyDutyHat()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = -100
        };
        _customizations.Weather = weather;
        _hatLayersFactory.RegisterAllLayers(_customizations);

        //act
        var layer = _hatLayersFactory.GetLayer();

        //assert
        Assert.True(layer.GetType() == typeof(HeavyDutyHat));
    }
}
