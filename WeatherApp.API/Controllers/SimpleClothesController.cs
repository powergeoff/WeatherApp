using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;
using WeatherApp.Services.Models;
using WeatherApp.Services.OpenWeatherMap;
using WeatherApp.Services.SimpleClothes;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class SimpleClothesController : ControllerBase
{
    private ISimpleClothesService _clothesService;
    public SimpleClothesController(ISimpleClothesService clothesService)
    {
        _clothesService = clothesService;
    }

    [HttpGet]
    public async Task<ClothesStart> GetByCoords(double latitude, double longitude)
    {
        return await _clothesService.GetClothesByCoords(latitude, longitude);
    }
}