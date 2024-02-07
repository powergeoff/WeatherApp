using System.Collections.Generic;

namespace WeatherApp.Services.FactoryPattern;

public abstract class LayersFactory
{
    //registers a List of layers
    protected List<Layer> Layers { get; set; }

    public LayersFactory()
    {
        Layers = new List<Layer>();
    }
    protected void Register(Layer layer)
    {
        Layers.Add(layer);
    }

    protected void UnRegisterAll()
    {
        Layers = new List<Layer>();
    }

}