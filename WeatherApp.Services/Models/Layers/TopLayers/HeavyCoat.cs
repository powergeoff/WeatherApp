namespace WeatherApp.Services.Models.Layers.TopLayers;

public class HeavyCoat : Layer
{
    public HeavyCoat(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.HeavyDutytMaxTemp);
    }
}