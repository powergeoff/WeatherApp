using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Db.Models;
using WeatherApp.Db.Repositories;
using WeatherApp.Services.Models;
using WeatherApp.Services.SimpleClothes;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RegisterUserController : ControllerBase
{
    private IUserRepository _userRepository;
    private ILogger<RegisterUserController> _logger;
    public RegisterUserController(ILogger<RegisterUserController> logger, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        try
        {
            var newUser = await _userRepository.InsertUser(user);
            if (newUser)
            {
                await _userRepository.Save();
                return Ok($"User ${user.UserName} successfully created");
            }
            else
                return BadRequest("User already exists");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
    }
}