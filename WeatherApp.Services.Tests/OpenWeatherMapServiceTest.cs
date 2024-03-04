
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;
using WeatherApp.Services.Tests.Models;

namespace WeatherApp.Services.Tests;


public class OpenWeatherMapServiceTest
{
    private HttpClient _httpClient;
    private IConfigService _config;

    private IWeatherService _openWeatherMapService;
    public OpenWeatherMapServiceTest()
    {

        var builder = WebApplication.CreateBuilder();

        _config = new ConfigService(builder.Configuration);

        _httpClient = new HttpClient();

        _openWeatherMapService = new OpenWeatherMapService(_httpClient, _config);
    }

    [Fact]
    public async void GetWeather_ShouldReturnBoston()
    {

        WeatherForCreationDTO weatherForCreationDTO = new WeatherForCreationDTO
        {
            Latitude = TestConstants.BostonLatitude,
            Longitude = TestConstants.BostonLongitude
        };

        var result = await _openWeatherMapService.GetWeather(weatherForCreationDTO);

        Assert.True(result.City.Equals("Boston"));
    }

    [Fact]
    public async void GetWeather_ShouldReturnDenver()
    {


        WeatherForCreationDTO weatherForCreationDTO = new WeatherForCreationDTO
        {
            Latitude = 39.742043,
            Longitude = -104.991531
        };

        var result = await _openWeatherMapService.GetWeather(weatherForCreationDTO);

        Assert.True(result.City.Equals("Denver"));
    }
}