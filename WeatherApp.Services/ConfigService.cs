
using Microsoft.Extensions.Configuration;
public interface IConfigService
{
    string AppVersion { get; }
    string ConnectionString { get; }
    string APIKey { get; }
}

public class ConfigService : IConfigService
{
    private readonly IConfiguration _config;

    public ConfigService(IConfiguration config)
    {
        _config = config;
    }
    public string AppVersion => _config.GetValue<string>("AppVersion");

    public string APIKey => _config.GetValue<string>("APIKey");

    public string ConnectionString => _config.GetSection("Connections").GetValue<string>("Default");
}