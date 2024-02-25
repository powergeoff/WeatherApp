
namespace WeatherApp.Domain.Entities;
public class UserLogin : EntityBase
{
    public required string UserName { get; set; }
    public required string Password { get; set; }

}