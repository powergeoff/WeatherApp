using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class LongSleeveTShirt : Layer
{
    public LongSleeveTShirt(int offset) : base(LayerConstants.LongSleeveTShirtMaxTemp + offset)
    {
    }
}