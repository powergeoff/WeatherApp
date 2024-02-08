using System;
using System.Text.Json.Serialization;
using WeatherApp.Services.Models.Layers;

namespace WeatherApp.Services.Models;

public class Clothes
{
    public bool Gloves { get; set; }
    public string Hat { get; set; }
    public string[] TopLayers { get; set; }
    public string BottomLayer { get; set; }
    public string Overview { get; set; }

}