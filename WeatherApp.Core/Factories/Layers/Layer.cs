

namespace WeatherApp.Core.Factories.Layers;

public abstract class Layer : IObserver //each layer is an observer. they get updated by the factory when Customizations change
{
    protected Range<int> TemperatureRange { get; set; }
    protected ILayerCustomizations Customizations { get; set; }

    public Layer(ILayerCustomizations customizations)
    {
        Customizations = customizations;
    }

    public virtual bool AddLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return TemperatureRange.ContainsValue(temperatureWithCustomizations);
    }
    public virtual bool RemoveLayer()
    {
        int temperatureWithCustomizations = (int)Customizations.Weather.FeelsLikeTemp + Customizations.ActivityLevel + Customizations.BodyTempLevel;
        return !TemperatureRange.ContainsValue(temperatureWithCustomizations);
    }
    public void Update(LayerCustomizations layerCustomizations) => Customizations = layerCustomizations;
}