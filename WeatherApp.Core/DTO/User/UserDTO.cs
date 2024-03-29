using WeatherApp.Core.Domain.Models;

namespace WeatherApp.Core.DTO;

public class UserDTO
{
    public required Guid Id { get; set; }
    public required string UserName { get; set; }
    public Roles Role { get; set; }
    public int ActivityLevel { get; set; }
    public int BodyTemp { get; set; }
}