using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Core.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<User> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);

        void Insert(User user);

        void Remove(User user);
    }
}