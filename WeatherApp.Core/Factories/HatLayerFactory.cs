
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Core.Factories.Layers.HatLayers;

namespace WeatherApp.Core.Factories;

public interface IHatLayerFactory : IGetLayer, IUpdateCustomizations
{
    void RegisterAllLayers(ILayerCustomizations layerCustomizations);
}

public class HatLayerFactory : LayersFactory, IHatLayerFactory
{
    private ILayerCustomizations _layerCustomizations;

    public HatLayerFactory()
    {//allow IOC container to grab an instance BUT only iterate register new Layers later when you actually have customizations
    }

    public override void RegisterAllLayers(ILayerCustomizations layerCustomizations)
    {
        _layerCustomizations = layerCustomizations;
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