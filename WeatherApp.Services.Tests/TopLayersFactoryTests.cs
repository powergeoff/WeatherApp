using Microsoft.VisualBasic;
using WeatherApp.Services.FactoryPattern;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.Tests;

public class TopLayersFactoryTests
{

    [Fact]
    public void GetLayers_ShouldReturnEmpty()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.TShirtMaxTemp
        };
        TopLayersFactory _topLayersFactory = new TopLayersFactory(weather);

        //act
        var layers = _topLayersFactory.GetLayers();

        //assert
        Assert.Empty(layers);
    }

    [Fact]
    public void GetLayers_ShouldReturnTshirt()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.TShirtMaxTemp - 1
        };
        TopLayersFactory _topLayersFactory = new TopLayersFactory(weather);

        //act
        var layers = _topLayersFactory.GetLayers();

        Assert.True(layers.Count == 1);
        Assert.True(layers[0].GetType() == typeof(FactoryPattern.TopLayers.TShirt));
    }

    [Fact]
    public void GetLayers_ShouldReturnTshirtLongSleevAndSweatshirt()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = LayerConstants.SweatShirtMaxTemp - 1
        };
        TopLayersFactory _topLayersFactory = new TopLayersFactory(weather);

        //act
        var layers = _topLayersFactory.GetLayers();

        Assert.True(layers.Count == 3);
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
        TopLayersFactory _topLayersFactory = new TopLayersFactory(weather);

        var layers = _topLayersFactory.GetLayers();

        //act
        Assert.True(layers.Count == 1);
        Assert.True(layers[0].GetType() == typeof(FactoryPattern.TopLayers.RainCoat));
    }

    [Fact]
    public void GetLayers_ShouldReturnAllLayers()
    {
        //arrange
        WeatherModel weather = new WeatherModel
        {
            FeelsLikeTemp = -100,
            IsRaining = true
        };
        TopLayersFactory _topLayersFactory = new TopLayersFactory(weather);

        var layers = _topLayersFactory.GetLayers();

        //act
        Assert.True(layers.Count == 6);
    }
}
