using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.HatLayers;

public class WinterHat : Layer
{
    public WinterHat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        SetThreshHold(LayerConstants.WinterHatMaxTemp);
    }

    public override bool AddLayer() => Customizations.Weather.FeelsLikeTemp > LayerConstants.HeavyDutytMaxTemp && Customizations.Weather.FeelsLikeTemp < ThreshHold;
}