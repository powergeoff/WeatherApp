using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class Jacket : Layer
{
    public Jacket(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.HeavyDutytMaxTemp + 1, LayerConstants.JacketMaxTemp);
    }
}