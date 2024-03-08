using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminUserController : ControllerBase
{

    private ILogger<AdminUserController> _logger;
    public AdminUserController(ILogger<AdminUserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("You are an admin role!");

    }
}