

namespace WeatherApp.Core.Factories.Layers.BottomLayers;

public class Shorts : Layer
{
    public Shorts(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.ShortsMaxTemp, 200);
    }
    public override bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return TemperatureRange.ContainsValue(temperatureWithCustomizations) || Customizations.ActivityLevel > 7;
    }

    public override string ToString() => "Shorts";
}