namespace WeatherApp.Core.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}