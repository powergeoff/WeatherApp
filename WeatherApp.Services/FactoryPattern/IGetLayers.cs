using System.Collections.Generic;

namespace WeatherApp.Services.FactoryPattern;

public interface IGetLayers
{
    List<Layer> GetLayers();
}