using WeatherApp.Core.Domain.Repositories;

namespace WeatherApp.Core.RepositoryServices;

public interface IRepositoryServiceManager
{
    ILogInService LogInService { get; }
    IUserService UserService { get; }
}

public class RepositoryServiceManager : IRepositoryServiceManager
{
    private readonly Lazy<ILogInService> _lazyLoginService;
    private readonly Lazy<IUserService> _lazyUserService;

    public RepositoryServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyLoginService = new Lazy<ILogInService>(() => new LogInService(repositoryManager));
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
    }
    public ILogInService LogInService => _lazyLoginService.Value;

    public IUserService UserService => _lazyUserService.Value;
}