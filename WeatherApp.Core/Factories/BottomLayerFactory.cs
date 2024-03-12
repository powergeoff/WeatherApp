using WeatherApp.Core.Factories.Layers;
using WeatherApp.Core.Factories.Layers.BottomLayers;

namespace WeatherApp.Core.Factories;

public interface IBottomLayerFactory : IGetLayer, IUpdateCustomizations
{
    void RegisterAllLayers(ILayerCustomizations layerCustomizations);
}

public class BottomLayerFactory : LayersFactory, IBottomLayerFactory
{
    private ILayerCustomizations _layerCustomizations;

    public BottomLayerFactory()
    {
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