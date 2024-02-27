
using WeatherApp.Domain.Repositories;
using WeatherApp.Services.Abstractions;

namespace WeatherApp.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserLoginService> _lazyUserLoginService;
    private readonly Lazy<IBodyTempService> _lazyBodyTempService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyUserLoginService = new Lazy<IUserLoginService>(() => new UserLoginService(repositoryManager));
        _lazyBodyTempService = new Lazy<IBodyTempService>(() => new BodyTempService(repositoryManager));
    }
    public IBodyTempService BodyTempService => _lazyBodyTempService.Value;

    public IUserLoginService UserLoginService => _lazyUserLoginService.Value;
}