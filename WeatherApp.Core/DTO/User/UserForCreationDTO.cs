using System.ComponentModel.DataAnnotations;
using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.DTO;

public class UserForCreationDTO
{
    [Required(ErrorMessage = "User Name is required")]
    [StringLength(10, ErrorMessage = "User Name cannot exceed 10 characters")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(10, ErrorMessage = "Password cannot exceed 10 characters")]
    public string Password { get; set; }

    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int ActivityLevel { get; set; }


    [Range(-10, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int BodyTemp { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}