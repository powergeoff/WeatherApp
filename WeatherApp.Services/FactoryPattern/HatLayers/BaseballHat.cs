using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.HatLayers;

public class BaseballHat : Layer
{
    public BaseballHat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        ThreshHold = LayerConstants.WinterHatMaxTemp;
    }
    public override bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return ThreshHold < temperatureWithCustomizations && Customizations.ActivityLevel > 7;
    }
}