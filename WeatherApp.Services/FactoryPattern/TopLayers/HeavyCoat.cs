using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class HeavyCoat : Layer
{
    public HeavyCoat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.HeavyDutytMaxTemp);
    }
}