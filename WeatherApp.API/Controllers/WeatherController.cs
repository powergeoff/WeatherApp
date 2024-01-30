using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services.Models;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class WeatherController : ControllerBase
{


    private readonly ILogger<WeatherController> _logger;
    private readonly IOpenWeatherMapService _openWeatherMapService;

    public WeatherController(ILogger<WeatherController> logger, IOpenWeatherMapService openWeatherMapService)
    {
        _logger = logger;
        _openWeatherMapService = openWeatherMapService;
    }

    [HttpGet]
    public Task<WeatherModel> GetByCoords(double latitude, double longitude)
    {
        return _openWeatherMapService.GetWeather(latitude, longitude);
    }

    [HttpGet]
    public Task<WeatherModel> GetByCityAndState(string city, string state)
    {
        //coordsFromCityNameService()
        return _openWeatherMapService.GetWeather(city, state);
    }

    [HttpGet]
    public Task<WeatherModel> GetByZipCode(string zip)
    {
        //coordsFromCityNameService()
        return _openWeatherMapService.GetWeather(zip);
    }
}