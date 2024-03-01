

using WeatherApp.Core.Factories.Layers;

namespace WeatherApp.Core.Factories;

public abstract class LayersFactory
{
    //contains a List of all child layers
    protected List<Layer> Layers { get; set; }

    public LayersFactory()
    {
        Layers = new List<Layer>();
    }

    public abstract void RegisterAllLayers(ILayerCustomizations layerCustomizations);

    protected void Register(Layer layer)
    {
        Layers.Add(layer);
    }

    protected void UnRegister(Layer layer)
    {
        Layers.Remove(layer);
    }

    protected void UnRegisterAll()
    {
        Layers = new List<Layer>();
    }

}