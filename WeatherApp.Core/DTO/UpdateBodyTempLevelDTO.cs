using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Core.DTO;

public class UpdateBodyTempLevelDTO
{
    [Required(ErrorMessage = "You must supply an Body Temp Level")]
    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int UpdateBodyTemp { get; set; }
}