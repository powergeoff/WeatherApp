namespace WeatherApp.Core.Domain.Repositories
{
    public interface IRepositoryManager
    {
        ILogInRepository LoginRepository { get; }

        IUserRepository UserRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}