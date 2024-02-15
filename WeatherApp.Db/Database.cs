using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using WeatherApp.Services.Configuration;

namespace WeatherApp.Db;

public interface IDatabase
{
    Movie GetMovie();

    List<Movie> GetMovies();
}

public class Database : IDatabase
{

    private readonly IConfigService _config;
    private MongoClient _client;

    public Database(IConfigService config)
    {
        _config = config;

        var connectionString = _config.ConnectionString;

        _client = new MongoClient(connectionString);
    }

    public Movie GetMovie()
    {
        var db = MflixDbContext.Create(_client.GetDatabase("sample_mflix")); //map db context to mongo cluster's database ir "sample_mflix"

        return db.Movies.First(m => m.title == "Back to the Future");
    }

    public List<Movie> GetMovies()
    {
        var connectionString = _config.ConnectionString;

        var client = new MongoClient(connectionString);

        var db = MflixDbContext.Create(client.GetDatabase("sample_mflix"));

        return db.Movies.Take(10).ToList();
    }
}