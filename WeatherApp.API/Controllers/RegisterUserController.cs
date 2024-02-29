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
    private readonly IServiceManager _serviceManager;
    private ILogger<RegisterUserController> _logger;
    public RegisterUserController(ILogger<RegisterUserController> logger, IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLogin([FromBody] LogInForCreationDTO logInForCreationDTO)
    {
        var logInDTO = await _serviceManager.LogInService.CreateLogIn(logInForCreationDTO);
        return CreatedAtAction(nameof(GetLoginById), new { logInId = logInDTO.Id }, logInDTO);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLogins(CancellationToken cancellationToken)
    {
        var users = await _serviceManager.LogInService.GetAllLogIns(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{logInId:guid}")]
    public async Task<IActionResult> GetLoginById(Guid logInId, CancellationToken cancellationToken)
    {
        var logInDto = await _serviceManager.LogInService.GetLogInById(logInId, cancellationToken);

        return Ok(logInDto);
    }
}