using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.Services.Tests;

public class OpenWeatherMapServiceTest
{

    [Fact]
    public async void GetWeather_ShouldReturnBoston()
    {
        HttpClient httpClient = new HttpClient();
        var weatherService = new OpenWeatherMapService(httpClient);
        var result = await weatherService.GetWeather();

        Assert.True(result.City.Equals("Boston"));
    }

    [Fact]
    public async void GetWeather_ShouldReturnDenver()
    {
        HttpClient httpClient = new HttpClient();
        var weatherService = new OpenWeatherMapService(httpClient);
        var result = await weatherService.GetWeather(39.742043, -104.991531);

        Assert.True(result.City.Equals("Denver"));
    }
}