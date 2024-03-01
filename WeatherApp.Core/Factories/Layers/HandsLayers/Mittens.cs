

using WeatherApp.Core.Domain.Services;

namespace WeatherApp.Core.Factories.Layers.HandsLayers;

public class Mittens : Layer
{
    public Mittens(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.HeavyDutytMaxTemp);
    }

    public override string ToString() => "Mittens";
}