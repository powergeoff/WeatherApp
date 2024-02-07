
namespace WeatherApp.Services.Models.Layers.TopLayers;

public class SweatShirt : Layer
{
    public SweatShirt(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(-100, LayerConstants.SweatShirtMaxTemp);
    }
}