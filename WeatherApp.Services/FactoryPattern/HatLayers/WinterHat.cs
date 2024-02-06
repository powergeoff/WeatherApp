using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.HatLayers;

public class WinterHat : Layer
{
    public WinterHat(int offset) : base(LayerConstants.WinterHatMaxTemp + offset)
    {

    }


}