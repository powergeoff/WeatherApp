using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.DTO;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Infrastructure.Builders;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ClothesController : ControllerBase
{
    private IClothesDirector _clothesDirector;
    private IOpenWeatherMapService _openWeatherMapService;
    private IRepositoryServiceManager _repositoryServiceManager;
    public ClothesController(IClothesDirector clothesDirector, IOpenWeatherMapService openWeatherMapService, IRepositoryServiceManager repositoryServiceManager)
    {
        _clothesDirector = clothesDirector;
        _openWeatherMapService = openWeatherMapService;
        _repositoryServiceManager = repositoryServiceManager;
    }

    [HttpGet]
    public async Task<Clothes> GetByCoords(Guid userId, double latitude, double longitude)
    {
        var user = await _repositoryServiceManager.UserService.GetUserById(userId);
        _openWeatherMapService.SetCoordinates(latitude, longitude);
        _clothesDirector.SetClothesBuilder(new StandardClothesBuilder(user, _openWeatherMapService));
        await _clothesDirector.ConstructClothes();
        return _clothesDirector.GetClothes();
    }
}