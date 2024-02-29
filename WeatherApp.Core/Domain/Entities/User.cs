using System.ComponentModel.DataAnnotations;
using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.Domain.Entities;

public class User
{
    public required Guid Id { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
    public BodyTemp BodyTemp { get; set; }
    public Guid LogInId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}