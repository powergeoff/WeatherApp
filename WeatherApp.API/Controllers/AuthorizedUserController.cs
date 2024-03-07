using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class AuthorizedUserController : ControllerBase
{

    private ILogger<AuthorizedUserController> _logger;
    public AuthorizedUserController(ILogger<AuthorizedUserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("You are authorized!");
    }
}