

namespace WeatherApp.Contracts;
public class BodyTempDTO
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public required Guid UserId { get; set; }
    public required int TemperatureScale { get; set; }

}