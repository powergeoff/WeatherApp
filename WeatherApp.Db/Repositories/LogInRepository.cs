using Microsoft.EntityFrameworkCore;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.Repositories;

namespace WeatherApp.Db.Repositories;

public class LoginRepository : ILogInRepository
{
    private readonly WeatherAppDbContext _dbContext;
    public LoginRepository(WeatherAppDbContext dbContext) => _dbContext = dbContext;
    public async Task<IEnumerable<LogIn>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.LogIns.ToListAsync(cancellationToken);
    public async Task<LogIn?> GetByIdAsync(Guid userLoginId, CancellationToken cancellationToken = default) =>
        await _dbContext.LogIns.FirstOrDefaultAsync(x => x.Id == userLoginId, cancellationToken);
    public async Task<LogIn?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default) =>
        await _dbContext.LogIns.FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);
    public void Insert(LogIn logIn) => _dbContext.LogIns.Add(logIn);
    public void Remove(LogIn logIn) => _dbContext.LogIns.Remove(logIn);
}