using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.HatLayers;

public class BaseballHat : Layer
{
    public BaseballHat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
    }
    public override bool AddLayer()
    {
        return Customizations.ActivityLevel > 7;
    }
}