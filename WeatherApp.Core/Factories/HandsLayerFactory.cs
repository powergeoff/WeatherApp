

using WeatherApp.Core.Factories.Layers;
using WeatherApp.Core.Factories.Layers.HandsLayers;

namespace WeatherApp.Core.Factories;

public interface IHandsLayerFactory : IGetLayer, IUpdateCustomizations
{
    void RegisterAllLayers(ILayerCustomizations layerCustomizations);
}

public class HandsLayerFactory : LayersFactory, IHandsLayerFactory
{
    private ILayerCustomizations _layerCustomizations;

    public HandsLayerFactory()
    {//allow IOC container to grab an instance BUT only iterate register new Layers later when you actually have customizations
    }

    public override void RegisterAllLayers(ILayerCustomizations layerCustomizations)
    {
        _layerCustomizations = layerCustomizations;
        Register(new WinterGloves(_layerCustomizations));
        Register(new Mittens(_layerCustomizations));
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