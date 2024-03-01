
using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.Domain.Entities;

public class User
{
    public required Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public Roles Role { get; set; }
    public int ActivityLevel { get; set; }
    public int BodyTemp { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}