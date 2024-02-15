using WeatherApp.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Db;

public class WeatherAppDbContext : DbContext
{
    public DbSet<User> Users { get; init; }

    public WeatherAppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(); //any db set up top needs to be included here
    }
}