using WeatherApp.Services.Models.Layers;
using WeatherApp.Services.Models.Layers.BottomLayers;

namespace WeatherApp.Services.Factories;

public interface IBottomLayerFactory : IGetLayer, IUpdateCustomizations
{
    void RegisterAllLayers(ILayerCustomizations layerCustomizations);
}

public class BottomLayerFactory : LayersFactory, IBottomLayerFactory
{
    private ILayerCustomizations _layerCustomizations;

    public BottomLayerFactory()
    {//allow IOC container to grab an instance BUT only iterate register new Layers later when you actually have customizations
    }

    public override void RegisterAllLayers(ILayerCustomizations layerCustomizations)
    {
        _layerCustomizations = layerCustomizations;
        Register(new Shorts(_layerCustomizations));
        Register(new Pants(_layerCustomizations));
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