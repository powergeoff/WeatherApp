using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeatherApp.Core.Domain.ValueObjects;
using WeatherApp.Core.DTO;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;

namespace WeatherApp.Infrastructure.ApplicationServices;

public interface IGenerateTokenService
{
    //take in a userdto and see if it is valid
    //if the user is valid, assign roles and generate a token
    Task<string> GenerateToken(UserForUpdateDTO user);
}

public class GenerateTokenService : IGenerateTokenService
{
    private IConfigService _config;
    private readonly IRepositoryServiceManager _repositoryServiceManager;
    public GenerateTokenService(IConfigService config, IRepositoryServiceManager repositoryServiceManager)
    {
        _config = config;
        _repositoryServiceManager = repositoryServiceManager;
    }
    public async Task<string> GenerateToken(UserForUpdateDTO user)
    {
        var isValidUser = await _repositoryServiceManager.UserService.IsValidUser(user); //error handling happens here
        var validUser = await _repositoryServiceManager.UserService.GetUserByUserName(user.UserName);
        var authConfig = _config.AuthConfig;

        var expires = DateTime.UtcNow.AddMinutes(authConfig.Expires);
        var isAdmin = validUser.Role.Equals(Roles.Admin);

        var identity = GetClaimsIdentity(validUser.UserName, isAdmin, new List<string>());

        var token = GetToken(identity, expires, authConfig);

        return token;
    }

    private static ClaimsIdentity GetClaimsIdentity(
        string userName,
        bool isAdmin,
        List<string> roles
    )
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName)
        };

        if (isAdmin)
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        return new ClaimsIdentity(claims);
    }

    private static string GetToken(
        ClaimsIdentity identity,
        DateTime expires,
        AuthConfigModel authConfig
    )
    {
        var handler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.Key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = handler.CreateJwtSecurityToken(
            subject: identity,
            signingCredentials: signingCredentials,
            audience: authConfig.Audience,
            issuer: authConfig.Issuer,
            expires: expires
        );

        /*var Sectoken = new JwtSecurityToken(authConfig.Issuer,
          authConfig.Issuer,
          identity.Claims,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: signingCredentials);

        var newToken = new JwtSecurityTokenHandler().WriteToken(Sectoken);

        return newToken;*/

        return handler.WriteToken(token);
    }
}