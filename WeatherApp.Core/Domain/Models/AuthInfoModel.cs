using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Core.Domain.Models;

public class AuthInfoModel
{
    public User User { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
}