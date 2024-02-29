using WeatherApp.Core.Domain.ValueObjects;

namespace WeatherApp.Core.Domain.Services;

public class HelperMethods
{
    public static OrdinalDirection ConvertWindDirection(int degrees)
    {
        var directions = Enum.GetNames(typeof(OrdinalDirection));
        //8 sections of 45 degrees each adding up to 360
        int index = (degrees + 23) / 45 % 8;
        if (Enum.TryParse(directions[index], true, out OrdinalDirection ret))
        {
            return ret;
        }
        else
            return OrdinalDirection.North;

    }
}