namespace WeatherApp.Services.Models.TopLayers;

public class RainCoat : Layer
{
    public RainCoat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
    }

    public override bool AddLayer() => Customizations.Weather.IsRaining;

    public override bool RemoveLayer() => !Customizations.Weather.IsRaining;
}