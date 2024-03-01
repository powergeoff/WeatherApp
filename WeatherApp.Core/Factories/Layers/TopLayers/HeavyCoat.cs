using WeatherApp.Core.Domain.Services;

namespace WeatherApp.Core.Factories.Layers.TopLayers;

public class HeavyCoat : Layer
{
    public HeavyCoat(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.HeavyDutytMaxTemp);
    }
    public override string ToString() => "Heavy Coat";
}