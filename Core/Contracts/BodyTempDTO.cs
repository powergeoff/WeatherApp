

namespace WeatherApp.Contracts;

//https://code-maze.com/onion-architecture-in-aspnetcore/
//services.abstractions next
public class BodyTempDTO
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public required Guid UserId { get; set; }
    public required int TemperatureScale { get; set; }

}