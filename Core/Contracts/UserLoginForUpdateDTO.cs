using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Contracts;
public class UserLoginForUpdateDTO
{
    [Required(ErrorMessage = "User Name is required")]
    [StringLength(60, ErrorMessage = "User Name can't be longer than 60 characters")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(10, ErrorMessage = "Password can't be longer than 10 characters")]
    public required string Password { get; set; }

}