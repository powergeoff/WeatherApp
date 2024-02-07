using WeatherApp.Services.Factories;
using WeatherApp.Services.Models;
using WeatherApp.Services.Models.HatLayers;

namespace WeatherApp.Services.Tests;

public class HatLayerFactoryTests
{
    private LayerCustomizations _customizations = new LayerCustomizations();

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

        HatLayerFactory _hatLayersFactory = new HatLayerFactory(_customizations);

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

        HatLayerFactory _hatLayersFactory = new HatLayerFactory(_customizations);

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
        HatLayerFactory _hatLayersFactory = new HatLayerFactory(_customizations);

        //act
        var layer = _hatLayersFactory.GetLayer();

        //assert
        Assert.True(layer.GetType() == typeof(HeavyDutyHat));
    }
}
