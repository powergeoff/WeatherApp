using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WeatherApp.Services.Models.Layers;

namespace WeatherApp.Services.Models;

public class Clothes
{
    public string Gloves { get; set; }
    public string Hat { get; set; }
    public List<string> TopLayers { get; set; }
    public string BottomLayer { get; set; }
    public string Overview { get; set; }

    public Clothes()
    {
        TopLayers = new List<string>();
    }

}