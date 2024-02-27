using Microsoft.AspNetCore.Mvc;
using WeatherApp.Contracts;
using WeatherApp.Services.Abstractions;

namespace WeatherApp.Presentation.Controllers;

[ApiController]
[Route("api/v1/userlogin")]
public class UserLoginController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UserLoginController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpPost]
    public async Task<IActionResult> CreateUserLogin([FromBody] UserLoginForCreationDTO userLoginForCreationDTO)
    {
        var userLoginDTO = await _serviceManager.UserLoginService.CreateUser(userLoginForCreationDTO);
        //return CreatedAtAction(nameof(CreateUserLogin), new { userId = userLoginDTO.Id }, userLoginDTO);
        return CreatedAtAction(nameof(GetUserLoginById), new { userId = userLoginDTO.Id }, userLoginDTO);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllUserLogins(CancellationToken cancellationToken)
    {
        var users = await _serviceManager.UserLoginService.GetAllUsers(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserLoginById(Guid userId, CancellationToken cancellationToken)
    {
        var ownerDto = await _serviceManager.UserLoginService.GetUserById(userId, cancellationToken);

        return Ok(ownerDto);
    }

    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateUserLogin(Guid userId, [FromBody] UserLoginForUpdateDTO userLoginForUpdateDTO, CancellationToken cancellationToken)
    {
        await _serviceManager.UserLoginService.UpdateUser(userId, userLoginForUpdateDTO, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{ownerId:guid}")]
    public async Task<IActionResult> DeleteUserLogin(Guid userId, CancellationToken cancellationToken)
    {
        await _serviceManager.UserLoginService.DeleteUser(userId, cancellationToken);

        return NoContent();
    }
}