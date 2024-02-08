using System;
using System.Text.Json.Serialization;
using WeatherApp.Services.Models.Layers;

namespace WeatherApp.Services.Models;

public class Clothes
{

    public string[] Tops { get; set; }
    public string Hat { get; set; }

}