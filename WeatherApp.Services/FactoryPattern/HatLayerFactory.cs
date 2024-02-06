using System.Collections.Generic;
using WeatherApp.Services.FactoryPattern.HatLayers;
using WeatherApp.Services.FactoryPattern.TopLayers;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern;

public class HatLayerFactory : LayersFactory, IGetLayer
{
    private LayerCustomizations _layerCustomizations;
    public HatLayerFactory(LayerCustomizations customizations)
    {
        _layerCustomizations = customizations;
        //register all available layers
        Register(new WinterHat(_layerCustomizations));
        Register(new HeavyDutyHat(_layerCustomizations));
        //Register(new BaseballHat());
    }

    public Layer GetLayer()
    {
        Layer hat = null;
        foreach (var layer in Layers)
        {
            if (layer.AddLayer())
                hat = layer;
        }

        return hat;
    }
}