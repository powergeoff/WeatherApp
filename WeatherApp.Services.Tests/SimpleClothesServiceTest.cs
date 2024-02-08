using WeatherApp.Services.OpenWeatherMap;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WeatherApp.Services.Tests.Models;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.Tests;


public class SimpleClothesServiceTest
{

    private IOpenWeatherMapService _openWeatherMapService;
    private ISimpleClothesService _clothesService;
    public SimpleClothesServiceTest()
    {
        var file = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"));
        var config = JsonSerializer.Deserialize<Config>(file)!;

        var configManager = new ConfigurationManager();

        configManager.AddInMemoryCollection([
                new KeyValuePair<string, string?>("APIKey", config.APIKey),
            ])
            .Build();

        _openWeatherMapService = new OpenWeatherMapService(new HttpClient(), new ConfigService(configManager));
        _clothesService = new SimpleClothesService(_openWeatherMapService);
    }

    [Fact]
    public async void GetClothes_ShouldReturnData()
    {
        var result = await _clothesService.GetClothesByCoords(TestConstants.BostonLatitude, TestConstants.BostonLongitude);

        Assert.NotNull(result);
    }

}