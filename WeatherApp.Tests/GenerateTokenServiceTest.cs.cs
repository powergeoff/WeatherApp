
using WeatherApp.Core.Domain.Exceptions;
using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.DTO;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Infrastructure.ApplicationServices;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;

namespace WeatherApp.Services.Tests;


public class GenerateTokenServiceTest
{
    private IConfigService _config;

    public GenerateTokenServiceTest()
    {
        var builder = WebApplication.CreateBuilder();

        _config = new ConfigService(builder.Configuration)
        {
            AuthConfig = new AuthConfigModel
            {
                Expires = 10,
                Key = "02092024_YourSecretKeyForAuthenticationOfApplication",
                Audience = "http://localhost:5001/",
                Issuer = "Vt Auth Server",
            }
        };

    }

    [Fact]
    public async void ServiceShouldReturnToken()
    {
        var repoManagerMock = MockIRepositoryServiceManager.GetMock();
        var tokenService = new GenerateTokenService(_config, repoManagerMock.Object);

        var userDTO = new UserForUpdateDTO()
        {
            UserName = "Admin",
            Password = "Password"
        };
        var authInfoModel = await tokenService.GenerateToken(userDTO);

        Assert.NotEmpty(authInfoModel.Token);
    }

    [Fact]
    public async void ServiceShouldFail_BadUser()
    {
        var repoManagerMock = MockIRepositoryServiceManager.GetMock();
        var tokenService = new GenerateTokenService(_config, repoManagerMock.Object);

        var userDTO = new UserForUpdateDTO()
        {
            UserName = "BadUser",
            Password = "Password"
        };

        AuthInfoModel authInfoModel = new AuthInfoModel();
        try
        {
            authInfoModel = await tokenService.GenerateToken(userDTO);
        }
        catch (UserNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        Assert.Null(authInfoModel.Token);
    }

}