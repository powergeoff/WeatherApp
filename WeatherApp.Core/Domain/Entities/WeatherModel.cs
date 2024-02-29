using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.Domain.Entities;

public class WeatherModel
{
    public string City { get; set; }
    public string Overall { get; set; }
    public string Description { get; set; }
    public double Temperature { get; set; }
    public double FeelsLikeTemp { get; set; }
    public decimal Humidity { get; set; }
    public bool IsRaining { get; set; }
    public bool IsSnowing { get; set; }

    public double WindSpeed { get; set; }
    public OrdinalDirection WindDirection { get; set; }
}