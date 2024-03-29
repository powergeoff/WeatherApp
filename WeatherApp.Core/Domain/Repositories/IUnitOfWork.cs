using System.Threading;
using System.Threading.Tasks;

namespace WeatherApp.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}