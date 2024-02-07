namespace WeatherApp.Services.Models.TopLayers;

public class HeavyCoat : Layer
{
    public HeavyCoat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.HeavyDutytMaxTemp);
    }
}