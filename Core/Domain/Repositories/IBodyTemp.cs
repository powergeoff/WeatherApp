using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Domain.Repositories
{
    public interface IBodyTempRepository
    {
        Task<IEnumerable<BodyTemp>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<BodyTemp?> GetByIdAsync(Guid bodyTempId, CancellationToken cancellationToken = default);

        void Insert(BodyTemp bodyTemp);

        void Remove(BodyTemp bodyTemp);
    }
}