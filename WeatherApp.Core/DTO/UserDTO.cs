using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.DTO;

public class UserDTO
{
    public required Guid Id { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
    public BodyTemp BodyTemp { get; set; }
    public Guid LogInId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}