namespace WeatherApp.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUserLoginRepository OwnerRepository { get; }

        IBodyTempRepository AccountRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
