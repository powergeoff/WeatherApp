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

    //should pass a weather data model to use more than current temp
    //pass the customizations instead of weather
    public virtual bool AddLayer()
    {
        int threshHoldWithCustomizations = ThreshHold + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return Customizations.Weather.FeelsLikeTemp < threshHoldWithCustomizations;
    }
    public virtual bool RemoveLayer()
    {
        int threshHoldWithCustomizations = ThreshHold + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return Customizations.Weather.FeelsLikeTemp > threshHoldWithCustomizations;
    }
    public void Update(LayerCustomizations layerCustomizations) => Customizations = layerCustomizations;
}