using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core.DTO;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Db.Repositories;

namespace WeatherApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IRepositoryServiceManager _repositoryServiceManager;
    private ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger, IRepositoryServiceManager repositoryServiceManager)
    {
        _repositoryServiceManager = repositoryServiceManager;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForCreationDTO)
    {
        var userDTO = await _repositoryServiceManager.UserService.CreateUser(userForCreationDTO);
        return CreatedAtAction(nameof(GetUserById), new { userId = userDTO.Id }, userDTO);
    }

    [HttpGet]//testing only
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await _repositoryServiceManager.UserService.GetAllUsers(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        var userDTO = await _repositoryServiceManager.UserService.GetUserById(userId, cancellationToken);

        return Ok(userDTO);
    }

    [Authorize]
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateUserName(Guid userId, [FromBody] UpdateUserNameDTO userForUpdateDto, CancellationToken cancellationToken)
    {
        await _repositoryServiceManager.UserService.UpdateUserName(userId, userForUpdateDto, cancellationToken);

        return NoContent();
    }


    [Authorize]
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdatePassword(Guid userId, [FromBody] UpdatePasswordDTO userForUpdateDto, CancellationToken cancellationToken)
    {
        await _repositoryServiceManager.UserService.UpdatePassword(userId, userForUpdateDto, cancellationToken);

        return NoContent();
    }


    [Authorize]
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateBodyTemp(Guid userId, [FromBody] UpdateBodyTempLevelDTO userForUpdateDto, CancellationToken cancellationToken)
    {
        await _repositoryServiceManager.UserService.UpdateBodyTemp(userId, userForUpdateDto, cancellationToken);

        return NoContent();
    }


    [Authorize]
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateActivityLevel(Guid userId, [FromBody] UpdateActivityLevelDTO userForUpdateDto, CancellationToken cancellationToken)
    {
        await _repositoryServiceManager.UserService.UpdateActivityLevel(userId, userForUpdateDto, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        await _repositoryServiceManager.UserService.DeleteUser(userId, cancellationToken);

        return NoContent();
    }
}