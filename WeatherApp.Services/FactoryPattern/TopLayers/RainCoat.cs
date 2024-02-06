using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class RainCoat : Layer
{
    public RainCoat()
    {
    }

    public override bool AddLayer(WeatherModel weather)
    {
        return weather.IsRaining;
    }
}