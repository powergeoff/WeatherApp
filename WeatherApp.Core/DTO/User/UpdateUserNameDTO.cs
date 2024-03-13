using System.ComponentModel.DataAnnotations;
using WeatherApp.Core.Domain.Models;

namespace WeatherApp.Core.DTO;

public class UpdateUserNameDTO
{
    [Required(ErrorMessage = "User Name is required")]
    [StringLength(10, ErrorMessage = "User Name cannot exceed 10 characters")]
    public string CurrentUserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(10, ErrorMessage = "Password cannot exceed 10 characters")]
    public string Password { get; set; }

    [Required(ErrorMessage = "New User Name is required")]
    [StringLength(10, ErrorMessage = "New User Name cannot exceed 10 characters")]
    public string NewUserName { get; set; }
}