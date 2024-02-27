//using Microsoft.AspNetCore.Identity.Data; //Maybe use mine in Models Folder?
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WeatherApp.Db.Repositories;
using WeatherApp.Services.Configuration;
using WeatherApp.Services.Models;

namespace WeatherApp.API.Controllers;

//https://medium.com/@vndpal/how-to-implement-jwt-token-authentication-in-net-core-6-ab7f48470f5c

/*[Route("api/v1/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private IConfigService _config;
    private IUserRepository _userRepository;
    private ILogger<LoginController> _logger;
    public LoginController(IConfigService config, ILogger<LoginController> logger, IUserRepository userRepository)
    {
        _config = config;
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LoginRequest loginRequest)
    {
        //your logic for login process
        //If login usrename and password are correct then proceed to generate token
        var user = await _userRepository.GetUserByName(loginRequest.UserName);
        if (user != null && user.Password == loginRequest.Password)
        {
            var authConfig = _config.AuthConfig;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(authConfig.Issuer,
              authConfig.Issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);

        }
        else
        {
            return BadRequest();
        }

    }
}*/