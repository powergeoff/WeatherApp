using System.Collections.Generic;

namespace WeatherApp.Services.FactoryPattern;

public interface IGetLayer
{
    Layer GetLayer(int currentTemp);
}