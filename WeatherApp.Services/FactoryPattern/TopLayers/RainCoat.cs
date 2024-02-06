using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class RainCoat : Layer
{
    public RainCoat()
    {
    }

    public override bool AddLayer(WeatherModel weather) => weather.IsRaining;

    public override bool RemoveLayer(WeatherModel weather) => !weather.IsRaining;
}