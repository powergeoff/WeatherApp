using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Core.DTO;

public class UpdateBodyTempAndActivityDTO
{
    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int ActivityLevel { get; set; }


    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int BodyTemp { get; set; }
}