
using WeatherApp.Core.Domain.Services;

namespace WeatherApp.Core.Factories.Layers.TopLayers;

public class SweatShirt : Layer
{
    public SweatShirt(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.SweatShirtMaxTemp);
    }
    public override string ToString() => "Sweat Shirt";
}