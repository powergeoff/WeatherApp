using WeatherApp.Services.OpenWeatherMap;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WeatherApp.Services.Tests.Models;
using WeatherApp.Services.Configuration;
using Microsoft.AspNetCore.Builder;

namespace WeatherApp.Services.Tests;


public class ConfigurationTest
{
    private IConfigService _config;

    public ConfigurationTest()
    {
        var builder = WebApplication.CreateBuilder();
        //below fails to be overwritten in ci pipeline
        //if it's not here the tests fail
        //builder.Configuration.AddJsonFile("appsettings.Development.json");

        _config = new ConfigService(builder.Configuration);
    }

    [Fact]
    public void APIKey_ShouldBePopulated()
    {
        Assert.NotEmpty(_config.APIKey);
    }

}