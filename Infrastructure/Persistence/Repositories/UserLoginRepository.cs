using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;
using WeatherApp.Domain.Repositories;

namespace WeatherApp.Persistence.Repositories;

internal sealed class UserLoginRepository : IUserLoginRepository
{
    private readonly RepositoryDbContext _dbContext;
    public UserLoginRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    public async Task<IEnumerable<UserLogin>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.UserLogins.ToListAsync(cancellationToken);
    public async Task<UserLogin?> GetByIdAsync(Guid userLoginId, CancellationToken cancellationToken = default) =>
        await _dbContext.UserLogins.FirstOrDefaultAsync(x => x.Id == userLoginId, cancellationToken);
    public async Task<UserLogin?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default) =>
        await _dbContext.UserLogins.FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);
    public void Insert(UserLogin userLogin) => _dbContext.UserLogins.Add(userLogin);
    public void Remove(UserLogin userLogin) => _dbContext.UserLogins.Remove(userLogin);
}

//MAYBE make a presentation layer with controllers