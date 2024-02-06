using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class TShirt : Layer
{
    public TShirt(int offset) : base(LayerConstants.TShirtMaxTemp + offset)
    {
    }
}