using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.HatLayers;

public class BaseballHat : Layer
{
    public BaseballHat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.WinterHatMaxTemp + 1, 200);
    }
    public override bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return TemperatureRange.ContainsValue(temperatureWithCustomizations) && Customizations.ActivityLevel > 7;
    }
}