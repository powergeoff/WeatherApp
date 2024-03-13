//using Microsoft.AspNetCore.Identity.Data; //Maybe use mine in Models Folder?
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WeatherApp.Core.DTO;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Infrastructure.ApplicationServices;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;

namespace WeatherApp.API.Controllers;

//https://medium.com/@vndpal/how-to-implement-jwt-token-authentication-in-net-core-6-ab7f48470f5c

[Route("api/v1/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IGenerateTokenService _generateTokenService;
    private ILogger<LoginController> _logger;
    public LoginController(ILogger<LoginController> logger, IGenerateTokenService generateTokenService)
    {
        _generateTokenService = generateTokenService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserForUpdateDTO loginRequest)
    {
        var authInfoModel = await _generateTokenService.GenerateToken(loginRequest);
        return Ok(authInfoModel);

    }
}