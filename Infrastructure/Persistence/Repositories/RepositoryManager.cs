using WeatherApp.Domain;
using WeatherApp.Domain.Repositories;

namespace WeatherApp.Persistence.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IUserLoginRepository> _lazyUserLoginRepository;
    private readonly Lazy<IBodyTempRepository> _lazyBodyTempRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(RepositoryDbContext dbContext)
    {
        _lazyUserLoginRepository = new Lazy<IUserLoginRepository>(() => new UserLoginRepository(dbContext));
        _lazyBodyTempRepository = new Lazy<IBodyTempRepository>(() => new BodyTempRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }
    public IUserLoginRepository UserLoginRepository => _lazyUserLoginRepository.Value;

    public IBodyTempRepository BodyTempRepository => _lazyBodyTempRepository.Value;

    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}