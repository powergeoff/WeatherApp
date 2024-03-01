using WeatherApp.Core.Factories.Layers;

namespace WeatherApp.Core.Factories;

public interface IObserver
{
    void Update(LayerCustomizations layerCustomizations);
}