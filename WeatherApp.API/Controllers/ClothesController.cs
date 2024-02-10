using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;
using WeatherApp.Services.Builders;
using WeatherApp.Services.Models;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ClothesController : ControllerBase
{
    private IClothesDirector _clothesDirector;
    private IOpenWeatherMapService _openWeatherMapService;
    public ClothesController(IClothesDirector clothesDirector, IOpenWeatherMapService openWeatherMapService)
    {
        _clothesDirector = clothesDirector;
        _openWeatherMapService = openWeatherMapService;
    }

    [HttpGet]
    public async Task<Clothes> GetByCoords(double latitude, double longitude)
    {
        _openWeatherMapService.SetCoordinates(latitude, longitude);
        await _clothesDirector.ConstructClothes();
        return _clothesDirector.GetClothes();
    }
}