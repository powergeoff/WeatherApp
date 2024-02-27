namespace WeatherApp.Services.Abstractions;

public interface IServiceManager
{
    IBodyTempService BodyTempService { get; }
    IUserLoginService UserLoginService { get; }
}