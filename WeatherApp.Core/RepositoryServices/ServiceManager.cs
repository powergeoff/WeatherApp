using WeatherApp.Core.Domain.Repositories;

namespace WeatherApp.Core.RepositoryServices;

public interface IServiceManager
{
    ILogInService LogInService { get; }
    IUserService UserService { get; }
}

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ILogInService> _lazyLoginService;
    private readonly Lazy<IUserService> _lazyUserService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyLoginService = new Lazy<ILogInService>(() => new LogInService(repositoryManager));
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
    }
    public ILogInService LogInService => _lazyLoginService.Value;

    public IUserService UserService => _lazyUserService.Value;
}