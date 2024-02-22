
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace WeatherApp.Services.Configuration;

public interface IConfigService
{
    JsonSerializerOptions JsonSettings { get; set; }
    string AppVersion { get; set; }
    string ConnectionString { get; set; }
    string DbName { get; set; }
    string APIKey { get; set; }
    AuthConfigModel AuthConfig { get; set; }
}

public class ConfigService : IConfigService
{
    private readonly IConfiguration _config;

    public ConfigService()
    {
    }

    public ConfigService(IConfiguration config)
    {
        _config = config;

        JsonSettings = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        };
        APIKey = _config["OpenWeatherMap:ApiKey"];
        AppVersion = _config.GetValue<string>("AppVersion");
        AuthConfig = _config.GetSection("Auth").Get<AuthConfigModel>();
        ConnectionString = _config.GetSection("Connections").GetValue<string>("Default");
        DbName = _config.GetSection("Connections").GetValue<string>("DbName");
    }

    public JsonSerializerOptions JsonSettings { get; set; }
    public string AppVersion { get; set; }

    public string APIKey { get; set; }

    public AuthConfigModel AuthConfig { get; set; }

    public string ConnectionString { get; set; }

    public string DbName { get; set; }

}