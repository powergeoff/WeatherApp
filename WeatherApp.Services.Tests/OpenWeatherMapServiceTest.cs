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

    private IOpenWeatherMapService _openWeatherMapService;
    public OpenWeatherMapServiceTest()
    {

        var builder = WebApplication.CreateBuilder();
        //nothing will be here unless set explicitly in environment variables for dotnet test
        _config = new ConfigService(builder.Configuration);

        _httpClient = new HttpClient();

        _openWeatherMapService = new OpenWeatherMapService(_httpClient, _config);
    }

    [Fact]
    public async void GetWeather_ShouldReturnBoston()
    {
        _openWeatherMapService.SetCoordinates(TestConstants.BostonLatitude, TestConstants.BostonLongitude);

        var result = await _openWeatherMapService.GetWeather();

        Assert.True(result.City.Equals("Boston"));
    }

    [Fact]
    public async void GetWeather_ShouldReturnDenver()
    {

        _openWeatherMapService.SetCoordinates(39.742043, -104.991531);

        var result = await _openWeatherMapService.GetWeather();

        Assert.True(result.City.Equals("Denver"));
    }
}