using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern;

public abstract class Layer : IObserver
{
    protected int ThreshHold { get; set; }
    protected LayerCustomizations Customizations { get; set; }

    public Layer(LayerCustomizations customizations)
    {
        Customizations = customizations;
    }

    public virtual bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return temperatureWithCustomizations < ThreshHold;
    }
    public virtual bool RemoveLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return temperatureWithCustomizations > ThreshHold;
    }
    public void Update(LayerCustomizations layerCustomizations) => Customizations = layerCustomizations;
}