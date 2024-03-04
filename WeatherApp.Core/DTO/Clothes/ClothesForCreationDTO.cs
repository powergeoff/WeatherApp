namespace WeatherApp.Core.DTO;

public class ClothesForCreationDTO
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public int ActivityLevel { get; set; }
    public int BodyTempLevel { get; set; }
}