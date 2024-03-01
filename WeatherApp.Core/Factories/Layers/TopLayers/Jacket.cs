using WeatherApp.Core.Domain.Services;

namespace WeatherApp.Core.Factories.Layers.TopLayers;

public class Jacket : Layer
{
    public Jacket(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.HeavyDutytMaxTemp + 1, LayerConstants.JacketMaxTemp);
    }
    public override string ToString() => "Jacket";
}