using System.ComponentModel.DataAnnotations;
using WeatherApp.Core.Domain.Models;

namespace WeatherApp.Core.DTO;

public class UserForUpdateDTO //update and login - same type
{
    [Required(ErrorMessage = "User Name is required")]
    [StringLength(10, ErrorMessage = "User Name cannot exceed 10 characters")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(10, ErrorMessage = "Password cannot exceed 10 characters")]
    public string Password { get; set; }
}