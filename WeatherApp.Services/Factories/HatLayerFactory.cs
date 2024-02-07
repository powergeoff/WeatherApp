using System.Collections.Generic;
using WeatherApp.Services.Models.HatLayers;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.Factories;

public class HatLayerFactory : LayersFactory, IGetLayer, IUpdateCustomizations
{
    private LayerCustomizations _layerCustomizations;
    public HatLayerFactory(LayerCustomizations customizations)
    {
        _layerCustomizations = customizations;
        //register all available layers
        Register(new BaseballHat(_layerCustomizations));
        Register(new WinterHat(_layerCustomizations));
        Register(new HeavyDutyHat(_layerCustomizations));
    }

    public void UpdateCustomizations(LayerCustomizations customizations)
    {
        foreach (var layer in Layers)
        {
            layer.Update(customizations);
        }
    }

    public Layer GetLayer()
    {
        Layer hat = null;
        foreach (var layer in Layers)
        {
            if (layer.AddLayer())
                return layer;
        }

        return hat;
    }
}