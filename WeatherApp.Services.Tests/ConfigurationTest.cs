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

        _config = new ConfigService(builder.Configuration);
    }

    [Fact]
    public void APIKey_ShouldBePopulated()
    {
        Assert.True(_config.APIKey.Equals("f2d3145194b8c69aa1f5c239ca1b687a"));
    }

}