using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class Jacket : Layer
{
    public Jacket(int offset) : base(LayerConstants.JacketMaxTemp + offset)
    {
    }
}