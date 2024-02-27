using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence;

public class RepositoryDbContext : DbContext
{
    public DbSet<UserLogin> UserLogins { get; init; }
    public DbSet<BodyTemp> BodyTemps { get; init; }

    public RepositoryDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserLogin>()
            .ToCollection("user_logins"); //any db set up top needs to be included here
        modelBuilder.Entity<BodyTemp>()
            .ToCollection("body_temps");
    }
}