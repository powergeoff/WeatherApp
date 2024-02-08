
namespace WeatherApp.Services.Models.Layers.TopLayers;

public class SweatShirt : Layer
{
    public SweatShirt(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.SweatShirtMaxTemp);
    }
}