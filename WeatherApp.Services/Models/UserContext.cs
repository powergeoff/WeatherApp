using WeatherApp.Services.Factories;
using WeatherApp.Services.Models.Layers;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.Services.Models;

public class UserContext
{
    public string Location { get; set; }
    public string Role { get; set; }
    public Clothes Clothes { get; set; }


}