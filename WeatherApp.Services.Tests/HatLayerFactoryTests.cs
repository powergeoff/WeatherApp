using WeatherApp.Services.FactoryPattern;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.Tests;

public class HatLayerFactoryTests
{

    /*[Fact]
    public void GetLayer_ShouldReturnEmpty()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.WinterHatMaxTemp
        };
        HatLayerFactory _hatLayersFactory = new HatLayerFactory(weather);

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
            FeelsLikeTemp = LayerConstants.WinterHatMaxTemp - 1
        };
        HatLayerFactory _hatLayersFactory = new HatLayerFactory(weather);

        //act
        var layer = _hatLayersFactory.GetLayer();

        //assert
        Assert.True(layer.GetType() == typeof(FactoryPattern.HatLayers.WinterHat));
    }

    [Fact]
    public void GetLayer_ShouldReturnHeavyDutyHat()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = -100
        };
        HatLayerFactory _hatLayersFactory = new HatLayerFactory(weather);

        //act
        var layer = _hatLayersFactory.GetLayer();

        //assert
        Assert.True(layer.GetType() == typeof(FactoryPattern.HatLayers.HeavyDutyHat));
    }*/
}
