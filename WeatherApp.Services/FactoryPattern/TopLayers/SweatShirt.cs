using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class SweatShirt : Layer
{
    public SweatShirt(int offset) : base(LayerConstants.SweatShirtMaxTemp + offset)
    {
    }
}