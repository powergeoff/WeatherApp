using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Core.Domain.Repositories
{
    public interface ILogInRepository
    {
        Task<IEnumerable<LogIn>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<LogIn> GetByIdAsync(Guid userLoginId, CancellationToken cancellationToken = default);
        Task<LogIn> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);

        void Insert(LogIn user);

        void Remove(LogIn userLogin);
    }
}