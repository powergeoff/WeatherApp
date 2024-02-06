using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern;

public abstract class Layer
{
    protected int ThreshHold { get; set; }
    protected LayerCustomizations Customizations { get; set; }

    public Layer(LayerCustomizations customizations)
    {
        Customizations = customizations;
    }

    protected void SetThreshHold(int threshhold)
    {
        ThreshHold = threshhold + Customizations.ActivityLevel + Customizations.BodyTempLevel;
    }
    //should pass a weather data model to use more than current temp
    //pass the customizations instead of weather
    public virtual bool AddLayer() => Customizations.Weather.FeelsLikeTemp < ThreshHold; //allow child classes to overwrite this
    public virtual bool RemoveLayer() => Customizations.Weather.FeelsLikeTemp > ThreshHold;
}