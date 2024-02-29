

using WeatherApp.Core.Domain.Services;

namespace WeatherApp.Core.Factories.Layers.HatLayers;

public class HeavyDutyHat : Layer
{
    public HeavyDutyHat(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.HeavyDutytMaxTemp);
    }

    public override string ToString() => "Heavy Duty Hat";
}