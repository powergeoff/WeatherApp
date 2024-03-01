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
    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default) =>
        await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);
    public void Insert(User user) => _dbContext.Users.Add(user);
    public void Remove(User user) => _dbContext.Users.Remove(user);
}
