

using WeatherApp.Core.Domain.Repositories;

namespace WeatherApp.Db.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<ILogInRepository> _lazyLoginRepository;
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(WeatherAppDbContext dbContext)
    {
        _lazyLoginRepository = new Lazy<ILogInRepository>(() => new LoginRepository(dbContext));
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }
    public ILogInRepository LoginRepository => _lazyLoginRepository.Value;

    public IUserRepository UserRepository => _lazyUserRepository.Value;

    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}