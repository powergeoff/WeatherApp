using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class LongSleeveTShirt : Layer
{
    public LongSleeveTShirt(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.LongSleeveTShirtMaxTemp);
    }
}