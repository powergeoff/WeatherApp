using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class Jacket : Layer
{
    public Jacket(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        SetThreshHold(LayerConstants.JacketMaxTemp);
    }
}