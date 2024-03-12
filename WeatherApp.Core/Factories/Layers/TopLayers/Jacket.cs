

namespace WeatherApp.Core.Factories.Layers.TopLayers;

public class Jacket : Layer
{
    public Jacket(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.HeavyDutytMaxTemp + 1, LayerConstants.JacketMaxTemp);
    }
    public override string ToString() => "Jacket";

    public override bool AddLayer() //no jacket if you're going for a run
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return TemperatureRange.ContainsValue(temperatureWithCustomizations) && Customizations.ActivityLevel < 7;
    }
}