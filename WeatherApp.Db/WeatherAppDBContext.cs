using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Db;

public class WeatherAppDbContext : DbContext
{
    public DbSet<LogIn> LogIns { get; init; }
    public DbSet<User> Users { get; init; }

    public WeatherAppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LogIn>()
            .ToCollection("logins"); //any db set up top needs to be included here
        modelBuilder.Entity<User>()
            .ToCollection("users");
    }
}