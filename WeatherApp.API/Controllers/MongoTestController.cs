using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Db;
using WeatherApp.Services.Models;
using WeatherApp.Services.SimpleClothes;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class MongoTestController : ControllerBase
{
    private IDatabase _database;
    public MongoTestController(IDatabase database)
    {
        _database = database;
    }

    [HttpGet]
    public Movie GetMovie()
    {
        return _database.GetMovie();
    }

    [HttpGet]
    public List<Movie> GetMovies()
    {
        return _database.GetMovies();
    }
}