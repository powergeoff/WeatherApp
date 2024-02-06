using WeatherApp.Services.Models;

namespace WeatherApp.Services.FactoryPattern;

public abstract class Layer
{
    protected int? _threshhold { get; set; }

    public Layer()
    { }

    public Layer(int threshhold)
    {
        _threshhold = threshhold;
    }
    //should pass a weather data model to use more than current temp
    //public virtual bool AddLayer(int currentTemp) => currentTemp < _threshhold; //allow child classes to overwrite this
    public virtual bool AddLayer(WeatherModel weather) => weather.FeelsLikeTemp < _threshhold; //allow child classes to overwrite this
    public virtual bool RemoveLayer(WeatherModel weather) => weather.FeelsLikeTemp > _threshhold;
}