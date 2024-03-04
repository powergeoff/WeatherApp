

namespace WeatherApp.Core.Factories.Layers.TopLayers;

public class LongSleeveTShirt : Layer
{
    public LongSleeveTShirt(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.LongSleeveTShirtMaxTemp);
    }
    public override string ToString() => "Long Sleeve T-Shirt";
}