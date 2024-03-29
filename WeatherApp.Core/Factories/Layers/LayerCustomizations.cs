using WeatherApp.Core.Domain.Models;

namespace WeatherApp.Core.Factories.Layers;

public interface ILayerCustomizations
{
    WeatherModel Weather { get; set; }
    int ActivityLevel { get; set; } //-10 - 10
    int BodyTempLevel { get; set; } //-10 - 10
}

public class LayerCustomizations : ILayerCustomizations
{
    public WeatherModel Weather { get; set; }
    public int ActivityLevel { get; set; } //-10 - 10
    public int BodyTempLevel { get; set; } //-10 - 10
}