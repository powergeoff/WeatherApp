using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.Services.Tests;

public class OpenWeatherMapServiceTest
{
    private HttpClient _httpClient;
    private IConfigService _config;
    public OpenWeatherMapServiceTest()
    {
        var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder([]);
        _httpClient = new HttpClient();
        _config = new ConfigService(builder);
    }
    //http://localhost:5000/swagger/index.html

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