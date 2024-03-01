using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Infrastructure.Builders;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

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