

namespace WeatherApp.Core.Factories.Layers.HandsLayers;

public class WinterGloves : Layer
{
    public WinterGloves(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        TemperatureRange = new Range<int>(LayerConstants.HeavyDutytMaxTemp + 1, LayerConstants.GlovesMaxTemp);
    }

    public override string ToString() => "Winter Gloves";
}