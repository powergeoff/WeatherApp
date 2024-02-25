
namespace WeatherApp.Contracts;
public class UserLoginDTO
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }

}