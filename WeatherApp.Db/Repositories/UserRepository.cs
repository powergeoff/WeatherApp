using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Db.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WeatherAppDbContext _dbContext;
    public UserRepository(WeatherAppDbContext dbContext) => _dbContext = dbContext;
    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Users.ToListAsync(cancellationToken);
    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
    public async Task<User?> GetByLogInIdAsync(Guid logInId, CancellationToken cancellationToken = default) =>
        await _dbContext.Users.FirstOrDefaultAsync(x => x.LogInId == logInId, cancellationToken);
    public void Insert(User user) => throw new NotImplementedException();
    public void Remove(User user) => throw new NotImplementedException();
}
