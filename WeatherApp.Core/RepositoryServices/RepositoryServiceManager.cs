using WeatherApp.Core.Domain.Repositories;

namespace WeatherApp.Core.RepositoryServices;

public interface IRepositoryServiceManager
{
    IUserService UserService { get; }
}

public class RepositoryServiceManager : IRepositoryServiceManager
{
    private readonly Lazy<IUserService> _lazyUserService;

    public RepositoryServiceManager(IRepositoryManager repositoryManager)
    {
        //every new repo or collection needs one of these
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
    }

    public IUserService UserService => _lazyUserService.Value;
}