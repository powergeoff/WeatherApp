

namespace WeatherApp.Services.Models.Layers.TopLayers;

public class TShirt : Layer
{
    public TShirt(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.LongSleeveTShirtMaxTemp + 1, LayerConstants.TShirtMaxTemp);
    }
}