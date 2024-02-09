using WeatherApp.Services.OpenWeatherMap;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WeatherApp.Services.Tests.Models;
using WeatherApp.Services.Configuration;

namespace WeatherApp.Services.Tests;


public class OpenWeatherMapServiceTest
{
    private HttpClient _httpClient;
    private IConfigService _config;
    public OpenWeatherMapServiceTest()
    {
        var file = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"));
        var config = JsonSerializer.Deserialize<Config>(file)!;

        var configManager = new ConfigurationManager();

        configManager.AddInMemoryCollection([
                new KeyValuePair<string, string?>("APIKey", config.APIKey),
            ])
            .Build();

        _config = new ConfigService(configManager);
        _httpClient = new HttpClient();
    }

    [Fact]
    public async void GetWeather_ShouldReturnBoston()
    {
        var weatherService = new OpenWeatherMapService(_httpClient, _config);
        var result = await weatherService.GetWeather(TestConstants.BostonLatitude, TestConstants.BostonLongitude);

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