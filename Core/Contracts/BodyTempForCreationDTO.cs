using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Contracts;
public class BodyTempForCreationDTO
{
    [Required(ErrorMessage = "User Id is required")]
    public required Guid UserId { get; set; }

    [DisplayName("Temperature Scale")]
    [Required(ErrorMessage = "Temperature Scale is required")]
    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public required int TemperatureScale { get; set; }

}