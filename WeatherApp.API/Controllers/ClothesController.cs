using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;
using WeatherApp.Services.Models;
using WeatherApp.Services.OpenWeatherMap;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ClothesController : ControllerBase
{
    private IClothesService _clothesService;
    public ClothesController(IClothesService clothesService)
    {
        _clothesService = clothesService;
    }

    [HttpGet]
    public async Task<Clothes> GetByCoords(double latitude, double longitude)
    {
        return await _clothesService.GetClothesByCoords(latitude, longitude);
    }
}