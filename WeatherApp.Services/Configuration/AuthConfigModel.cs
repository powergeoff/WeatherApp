namespace WeatherApp.Services.Configuration;

public class AuthConfigModel
{
    public string Key { get; set; }
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string PasswordSalt { get; set; }
    public int Expires { get; set; }
    public string KioskLogin { get; set; }
    public string KronosKey { get; set; }

}