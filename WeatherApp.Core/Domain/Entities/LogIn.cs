using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Core.Domain.Entities;

public class LogIn
{
    public required Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}