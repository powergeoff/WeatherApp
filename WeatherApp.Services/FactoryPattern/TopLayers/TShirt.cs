using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class TShirt : Layer
{
    public TShirt(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        SetThreshHold(LayerConstants.TShirtMaxTemp);
    }
}