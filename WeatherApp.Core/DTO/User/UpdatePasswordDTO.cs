using System.ComponentModel.DataAnnotations;
using WeatherApp.Core.Domain.Models;

namespace WeatherApp.Core.DTO;

public class UpdatePasswordDTO
{
    [Required(ErrorMessage = "User Name is required")]
    [StringLength(10, ErrorMessage = "User Name cannot exceed 10 characters")]
    public string CurrentUserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(10, ErrorMessage = "Password cannot exceed 10 characters")]
    public string Password { get; set; }

    [Required(ErrorMessage = "New Password is required")]
    [StringLength(10, ErrorMessage = "New Password cannot exceed 10 characters")]
    public string NewPassword { get; set; }
}