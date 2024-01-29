
using System.Text.Json;
using Microsoft.Extensions.Configuration;

public interface IConfigService
{
    JsonSerializerOptions JsonSettings { get; }
    string AppVersion { get; }
    //string ConnectionString { get; }
    string APIKey { get; }
}

public class ConfigService : IConfigService
{
    public JsonSerializerOptions JsonSettings { get; } =
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        };
    private readonly IConfiguration _config;

    public ConfigService(IConfiguration config)
    {
        _config = config;
    }
    public string AppVersion => _config.GetValue<string>("AppVersion");

    public string APIKey => _config.GetValue<string>("APIKey");

    //public string ConnectionString => _config.GetSection("Connections").GetValue<string>("Default");
}