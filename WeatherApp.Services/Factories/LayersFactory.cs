using System.Collections.Generic;
using WeatherApp.Services.Models.Layers;

namespace WeatherApp.Services.Factories;

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

    protected void UnRegister(Layer layer)
    {
        Layers.Remove(layer);
    }

    protected void UnRegisterAll()
    {
        Layers = new List<Layer>();
    }

}