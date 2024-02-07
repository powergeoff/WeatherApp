using WeatherApp.Services.Models.Layers;

namespace WeatherApp.Services.Factories;

public interface IUpdateCustomizations
{
    void UpdateCustomizations(LayerCustomizations customizations);
}