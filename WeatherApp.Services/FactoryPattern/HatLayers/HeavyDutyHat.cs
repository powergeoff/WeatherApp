using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.HatLayers;

public class HeavyDutyHat : Layer
{
    public HeavyDutyHat(int offset) : base(LayerConstants.HeavyDutytMaxTemp + offset)
    {
    }
}