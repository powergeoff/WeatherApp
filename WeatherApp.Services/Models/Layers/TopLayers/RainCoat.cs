namespace WeatherApp.Services.Models.Layers.TopLayers;

public class RainCoat : Layer
{
    public RainCoat(ILayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
    }

    public override bool AddLayer() => Customizations.Weather.IsRaining;

    public override bool RemoveLayer() => !Customizations.Weather.IsRaining;
}