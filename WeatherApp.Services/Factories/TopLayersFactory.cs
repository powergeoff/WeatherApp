using System;
using System.Collections.Generic;
using WeatherApp.Services.Models.Layers.TopLayers;
using WeatherApp.Services.Models.Layers;

namespace WeatherApp.Services.Factories;

public class TopLayersFactory : LayersFactory, IGetLayers, IUpdateCustomizations
{

    private LayerCustomizations _layerCustomizations;
    public TopLayersFactory(LayerCustomizations customizations)
    {
        Initialize(customizations);
    }

    private void Initialize(LayerCustomizations customizations)
    {
        _layerCustomizations = customizations;
        //register all available layers with base factory
        Register(new TShirt(_layerCustomizations));
        Register(new LongSleeveTShirt(_layerCustomizations));
        Register(new SweatShirt(_layerCustomizations));
        Register(new Jacket(_layerCustomizations));
        Register(new HeavyCoat(_layerCustomizations));
        Register(new RainCoat(_layerCustomizations));
    }

    //entry point to update all registered layers
    public void UpdateCustomizations(LayerCustomizations customizations)
    {
        foreach (var layer in Layers)
        {
            layer.Update(customizations);
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