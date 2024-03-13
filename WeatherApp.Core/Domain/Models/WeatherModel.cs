
namespace WeatherApp.Core.Domain.Models;

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
    public DateTime CreatedTime { get; set; }

    public static OrdinalDirection ConvertWindDirection(int degrees)
    {
        var directions = Enum.GetNames(typeof(OrdinalDirection));
        //8 sections of 45 degrees each adding up to 360
        int index = (degrees + 23) / 45 % 8;
        if (Enum.TryParse(directions[index], true, out OrdinalDirection ret))
        {
            return ret;
        }
        else
            return OrdinalDirection.North;

    }
}