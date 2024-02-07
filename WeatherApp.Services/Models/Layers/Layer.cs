using   WeatherApp.Services.Models;

namespace WeatherApp.Services.Models.Layers;

public abstract class Layer : IObserver
{
    protected Range<int> TemperatureRange { get; set; }
    protected LayerCustomizations Customizations { get; set; }

    public Layer(LayerCustomizations customizations)
    {
        Customizations = customizations;
    }

    public virtual bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return TemperatureRange.ContainsValue(temperatureWithCustomizations);
    }
    public virtual bool RemoveLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return !TemperatureRange.ContainsValue(temperatureWithCustomizations);
    }
    public void Update(LayerCustomizations layerCustomizations) => Customizations = layerCustomizations;
}