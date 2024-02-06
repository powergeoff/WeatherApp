using System.Collections.Generic;
using WeatherApp.Services.FactoryPattern.TopLayers;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern;

public class TopLayersFactory : LayersFactory, IGetLayers
{

    private LayerCustomizations _layerCustomizations;
    public TopLayersFactory(LayerCustomizations customizations)
    {
        _layerCustomizations = customizations;
        //register all available layers
        Register(new TShirt(_layerCustomizations));
        Register(new LongSleeveTShirt(_layerCustomizations));
        Register(new SweatShirt(_layerCustomizations));
        Register(new Jacket(_layerCustomizations));
        Register(new HeavyCoat(_layerCustomizations));
        Register(new RainCoat(_layerCustomizations));
    }

    //unused possible Observer Notify entry point
    public void UpdateCustomizations(LayerCustomizations customizations)
    {
        _layerCustomizations = customizations;
        //Notify()
    }

    private void Notify()
    {
        foreach (var layer in Layers)
        {
            //layer.update()
        }
    }

    public List<Layer> GetLayers()
    {
        List<Layer> topLayers = new List<Layer>();
        //delegate whether the layers should be added to child class
        foreach (var layer in Layers)
        {
            if (layer.AddLayer())
                topLayers.Add(layer);
        }
        return topLayers;
    }
}