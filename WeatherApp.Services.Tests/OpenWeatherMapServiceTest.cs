using WeatherApp.Services.OpenWeatherMap;
using Microsoft.Extensions.Configuration;

namespace WeatherApp.Services.Tests;


public class OpenWeatherMapServiceTest
{
    private HttpClient _httpClient;
    private IConfigService _config;
    public OpenWeatherMapServiceTest()
    {
        var configManager = new ConfigurationManager();

        configManager.AddInMemoryCollection([
                new KeyValuePair<string, string?>("APIKey", "f2d3145194b8c69aa1f5c239ca1b687a"),
            ])
            .Build();

        _config = new ConfigService(configManager);
        _httpClient = new HttpClient();
    }

    [Fact]
    public async void GetWeather_ShouldReturnBoston()
    {
        var weatherService = new OpenWeatherMapService(_httpClient, _config);
        var result = await weatherService.GetWeather();

        Assert.True(result.City.Equals("Boston"));
    }

    [Fact]
    public async void GetWeather_ShouldReturnDenver()
    {
        var weatherService = new OpenWeatherMapService(_httpClient, _config);
        var result = await weatherService.GetWeather(39.742043, -104.991531);

        Assert.True(result.City.Equals("Denver"));
    }
}