

namespace WeatherApp.Core.Factories.Layers.HatLayers;

public class BaseballHat : Layer
{
    public BaseballHat(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.WinterHatMaxTemp + 1, 200);
    }
    public override bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return TemperatureRange.ContainsValue(temperatureWithCustomizations) && Customizations.ActivityLevel > 7;
    }

    public override string ToString() => "Baseball Hat";
}