using System.Collections.Generic;

namespace WeatherApp.Services.Models;

public interface IGetLayers
{
    List<Layer> GetLayers();
}