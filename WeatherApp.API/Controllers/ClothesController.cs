using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.DTO;
using WeatherApp.Infrastructure.Builders;

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
    public async Task<Clothes> GetByCoords([FromQuery] ClothesForCreationDTO clothesForCreationDTO) //if user is logged in, their activityLevel and bodyTemps are passed in here
    {
        await _clothesDirector.ConstructClothes(clothesForCreationDTO);
        return _clothesDirector.GetClothes();
    }
}