using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Core.DTO;

public class UpdateActivityLevelDTO
{
    [Required(ErrorMessage = "You must supply an Activity Level")]
    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int ActivityLevel { get; set; }
}