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
    public ClothesController(IClothesDirector clothesDirector)
    {
        _clothesDirector = clothesDirector;
    }

    [HttpGet]
    public async Task<Clothes> GetByCoords(double latitude, double longitude)
    {
        await _clothesDirector.ConstructClothes(latitude, longitude);
        return _clothesDirector.GetClothes();
    }
}