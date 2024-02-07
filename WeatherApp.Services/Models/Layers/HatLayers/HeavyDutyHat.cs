

namespace WeatherApp.Services.Models.Layers.HatLayers;

public class HeavyDutyHat : Layer
{
    public HeavyDutyHat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.HeavyDutytMaxTemp);
    }
}