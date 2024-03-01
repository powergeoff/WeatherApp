using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Db;

namespace WeatherApp.Db.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly WeatherAppDbContext _dbContext;

    public UnitOfWork(WeatherAppDbContext dbContext) => _dbContext = dbContext;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}