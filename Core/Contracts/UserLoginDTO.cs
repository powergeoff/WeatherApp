
namespace WeatherApp.Contracts;
public class UserLoginDTO
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }

}