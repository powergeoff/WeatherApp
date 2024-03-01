

using WeatherApp.Core.Domain.Services;

namespace WeatherApp.Core.Factories.Layers.BottomLayers;

public class Pants : Layer
{
    public Pants(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.ShortsMaxTemp);
    }

    public override string ToString() => "Pants";
}