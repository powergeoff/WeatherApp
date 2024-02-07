namespace WeatherApp.Services.Models.TopLayers;

public class LongSleeveTShirt : Layer
{
    public LongSleeveTShirt(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.LongSleeveTShirtMaxTemp);
    }
}