using System;
using System.Collections.Generic;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Core.Factories.Layers.TopLayers;

namespace WeatherApp.Core.Factories;

public interface ITopLayersFactory : IGetLayer, IGetLayers, IUpdateCustomizations
{
    void RegisterAllLayers(ILayerCustomizations layerCustomizations);
}

public class TopLayersFactory : LayersFactory, ITopLayersFactory
{

    private ILayerCustomizations _layerCustomizations;

    public TopLayersFactory()
    {
    }
    public override void RegisterAllLayers(ILayerCustomizations layerCustomizations)
    {
        Initialize(layerCustomizations);
    }


    private void Initialize(ILayerCustomizations customizations)
    {
        _layerCustomizations = customizations;
        //register all available layers with base factory
        //this relies on the order - lightest first to heaviest or outermost
        //c# guarantees ordering
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

    public Layer GetLayer()//returns outermost layer
    {
        var layers = GetLayers();
        return layers[^1];
    }
}