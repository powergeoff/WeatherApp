using WeatherApp.Services.Models.Layers;

namespace WeatherApp.Services.Models;

public interface IObserver
{
    void Update(LayerCustomizations layerCustomizations);
}