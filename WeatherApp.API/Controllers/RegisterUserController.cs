using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core.DTO;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Db.Repositories;
using WeatherApp.Services.Models;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RegisterUserController : ControllerBase
{
    private readonly IRepositoryServiceManager _serviceManager;
    private ILogger<RegisterUserController> _logger;
    public RegisterUserController(ILogger<RegisterUserController> logger, IRepositoryServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserForCreationDTO userForCreationDTO)
    {
        var userDTO = await _serviceManager.UserService.CreateUser(userForCreationDTO);
        return CreatedAtAction(nameof(GetUserById), new { userId = userDTO.Id }, userDTO);
    }

    [HttpGet]//testing only
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await _serviceManager.UserService.GetAllUsers(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        var userDTO = await _serviceManager.UserService.GetUserById(userId, cancellationToken);

        return Ok(userDTO);
    }
}