using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.DTO;

public class UserDTO
{
    public required Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public int ActivityLevel { get; set; }
    public int BodyTemp { get; set; }
    public Guid LogInId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}