using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class WeatherController : ControllerBase
{
    private readonly ILogger<WeatherController> _logger;

    private readonly IExternalServicesManager _externalServicesManager;

    public WeatherController(ILogger<WeatherController> logger, IExternalServicesManager externalServicesManager)
    {
        _logger = logger;
        _externalServicesManager = externalServicesManager;
    }

    [HttpGet]
    public async Task<WeatherModel> GetByCoords([FromQuery] WeatherForCreationDTO weatherForCreationDTO)
    {
        return await _externalServicesManager.WeatherService.GetWeather(weatherForCreationDTO);
    }
}