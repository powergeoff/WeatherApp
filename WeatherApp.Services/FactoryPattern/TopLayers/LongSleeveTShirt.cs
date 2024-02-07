using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.TopLayers;

public class LongSleeveTShirt : Layer
{
    public LongSleeveTShirt(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        ThreshHold = LayerConstants.LongSleeveTShirtMaxTemp;
    }
}