namespace WeatherApp.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUserLoginRepository UserLoginRepository { get; }

        IBodyTempRepository BodyTempRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
