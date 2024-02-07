using WeatherApp.Services.Models;

namespace WeatherApp.Services.Models.Layers;

public class LayerCustomizations
{
    public WeatherModel Weather { get; set; }
    public int ActivityLevel { get; set; } //-10 - 10
    public int BodyTempLevel { get; set; } //-10 - 10
    //public int ThreshHold { get; set; }
}