using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;
using WeatherApp.Domain.Repositories;

namespace WeatherApp.Persistence.Repositories;

internal sealed class BodyTempRepository : IBodyTempRepository
{
    private readonly RepositoryDbContext _dbContext;
    public BodyTempRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<BodyTemp>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.BodyTemps.ToListAsync(cancellationToken);
    public async Task<BodyTemp?> GetByIdAsync(Guid bodyTempId, CancellationToken cancellationToken = default) =>
        await _dbContext.BodyTemps.FirstOrDefaultAsync(x => x.Id == bodyTempId);
    public void Insert(BodyTemp bodyTemp) => _dbContext.BodyTemps.Add(bodyTemp);
    public void Remove(BodyTemp bodyTemp) => _dbContext.BodyTemps.Remove(bodyTemp);
}