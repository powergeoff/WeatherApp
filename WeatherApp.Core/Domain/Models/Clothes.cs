
namespace WeatherApp.Core.Domain.Models;

public class Clothes
{
    public string Gloves { get; set; }
    public string Hat { get; set; }
    public List<string> TopLayers { get; set; }
    public string OutermostTopLayer { get; set; }
    public string BottomLayer { get; set; }
    public string Overview { get; set; }

    public Clothes()
    {
        TopLayers = new List<string>();
    }

}