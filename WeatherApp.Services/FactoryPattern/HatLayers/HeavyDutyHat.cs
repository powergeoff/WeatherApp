using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern.HatLayers;

public class HeavyDutyHat : Layer
{
    public HeavyDutyHat(LayerCustomizations layerCustomizations) : base(layerCustomizations)
    {
        SetThreshHold(LayerConstants.HeavyDutytMaxTemp);
    }
}