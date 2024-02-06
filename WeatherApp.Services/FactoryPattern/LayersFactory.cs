using System.Collections.Generic;

namespace WeatherApp.Services.FactoryPattern;

public abstract class LayersFactory
{
    //registers a List of layers
    //protected static List<Layer> Layers { get; set; }
    protected List<Layer> Layers { get; set; }

    public LayersFactory()
    {
        Layers = new List<Layer>();
    }
    protected void Register(Layer layer)
    {
        Layers.Add(layer);
    }

    protected void Remove(Layer layer)//unused but here for flexibility
    {
        Layers.Remove(layer);
    }

    //public abstract List<Layer> GetLayers(int currentTemp); ISP - hats are single layer
}