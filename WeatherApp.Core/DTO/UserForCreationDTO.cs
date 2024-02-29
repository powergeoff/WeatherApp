using System.ComponentModel.DataAnnotations;
using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.DTO;

public class UserForCreationDTO
{
    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public ActivityLevel ActivityLevel { get; set; }

    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public BodyTemp BodyTemp { get; set; }

    [Required(ErrorMessage = "LogIn Id is required for user")]
    public Guid LogInId { get; set; } //unique Login Id - so create a LogIn creates a user

    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}