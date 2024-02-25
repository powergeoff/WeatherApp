using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Domain.Repositories
{
    public interface IUserLoginRepository
    {
        Task<IEnumerable<UserLogin>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UserLogin> GetByIdAsync(Guid userLoginId, CancellationToken cancellationToken = default);

        void Insert(UserLogin userLogin);

        void Remove(UserLogin userLogin);
    }
}