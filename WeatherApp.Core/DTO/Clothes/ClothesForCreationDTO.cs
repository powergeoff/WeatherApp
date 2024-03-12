using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Core.DTO;

public class ClothesForCreationDTO
{
    public string ClothesBuilderType { get; set; } //unused but will allow for beach clothes, rink clothes etc...

    [Required(ErrorMessage = "Latitude is required")]
    public double Latitude { get; set; }

    [Required(ErrorMessage = "Longitude is required")]
    public double Longitude { get; set; }

    public int ActivityLevel { get; set; }
    public int BodyTempLevel { get; set; }
}