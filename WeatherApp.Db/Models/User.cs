using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace WeatherApp.Db.Models;

[Collection("users")]
public class User
{
    public ObjectId Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public DateTime? Created { get; set; } //properties added after init must allow nulls
    public DateTime? Modified { get; set; }

}