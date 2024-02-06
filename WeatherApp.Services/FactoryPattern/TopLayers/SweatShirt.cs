using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class SweatShirt : Layer
{
    public SweatShirt(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        SetThreshHold(LayerConstants.SweatShirtMaxTemp);
    }
}