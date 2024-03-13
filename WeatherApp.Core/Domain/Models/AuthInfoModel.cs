
using WeatherApp.Core.DTO;

namespace WeatherApp.Core.Domain.Models;

public class AuthInfoModel
{
    public UserDTO User { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
}