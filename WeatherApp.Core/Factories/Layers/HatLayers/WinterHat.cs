

namespace WeatherApp.Core.Factories.Layers.HatLayers;

public class WinterHat : Layer
{
    public WinterHat(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.HeavyDutytMaxTemp + 1, LayerConstants.WinterHatMaxTemp);
    }

    public override bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return TemperatureRange.ContainsValue(temperatureWithCustomizations);
    }
    public override string ToString() => "Winter Hat";
}