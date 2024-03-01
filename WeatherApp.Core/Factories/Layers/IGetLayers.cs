using System.Collections.Generic;

namespace WeatherApp.Core.Factories.Layers;

public interface IGetLayers
{
    List<Layer> GetLayers();
}