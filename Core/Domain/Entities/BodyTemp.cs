

namespace WeatherApp.Domain.Entities;
public class BodyTemp : EntityBase
{
    public required string UserId { get; set; }
    public required int TemperatureScale { get; set; }

}