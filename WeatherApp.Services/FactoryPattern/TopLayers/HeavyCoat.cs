using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class HeavyCoat : Layer
{
    public HeavyCoat(int offset) : base(LayerConstants.HeavyDutytMaxTemp + offset)
    {
    }
}