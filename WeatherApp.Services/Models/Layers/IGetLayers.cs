using System.Collections.Generic;

namespace WeatherApp.Services.Models.Layers;

public interface IGetLayers
{
    List<Layer> GetLayers();
}