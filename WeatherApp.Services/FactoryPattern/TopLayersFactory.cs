using System.Collections.Generic;
using WeatherApp.Services.FactoryPattern.TopLayers;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern;

public class TopLayersFactory : LayersFactory, IGetLayers
{
    private WeatherModel _weather;
    private int _temperatureOffset;
    public TopLayersFactory(WeatherModel weather, int temperatureOffset = 0)
    {
        _weather = weather;
        _temperatureOffset = temperatureOffset;
        //register all available layers
        Register(new TShirt(_temperatureOffset));
        Register(new LongSleeveTShirt(_temperatureOffset));
        Register(new SweatShirt(_temperatureOffset));
        Register(new Jacket(_temperatureOffset));
        Register(new HeavyCoat(_temperatureOffset));
        Register(new RainCoat());
    }

    public List<Layer> GetLayers()
    {
        List<Layer> topLayers = new List<Layer>();
        //delegate whether the layers should be added to child class
        foreach (var layer in Layers)
        {
            if (layer.AddLayer(_weather))
                topLayers.Add(layer);
        }
        return topLayers;
    }
}