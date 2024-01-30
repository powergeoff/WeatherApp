using System;

namespace WeatherApp.Services.Models;


public enum OrdinalDirection
{
  North,
  NorthEast,
  East,
  SouthEast,
  South,
  SothWest,
  West,
  NorthWest
}
public class WeatherModel
{
  public string City { get; set; }
  public string Overall { get; set; }
  public string Description { get; set; }
  public double Temperature { get; set; }
  public double FeelsLikeTemp { get; set; }
  public decimal Humidity { get; set; }
  public bool IsRaining { get; set; }
  public bool IsSnowing { get; set; }

  public double WindSpeed { get; set; }
  public OrdinalDirection WindDirection { get; set; }

  public static OrdinalDirection ConvertWindDirection(int degrees)
  {
    var directions = Enum.GetNames(typeof(OrdinalDirection));
    //8 sections of 45 degrees each adding up to 360
    int index = (degrees + 23) / 45 % 8;
    if (Enum.TryParse(directions[index], true, out OrdinalDirection ret))
    {
      return ret;
    }
    else return OrdinalDirection.North;

  }
}


// 20240125100429
// https://api.openweathermap.org/data/2.5/weather?lat=42.360081&lon=-71.058884&appid=f2d3145194b8c69aa1f5c239ca1b687a

/*{
  "coord": {
    "lon": -71.0583,
    "lat": 42.3603
  },
  "weather": [
    {
      "id": 804,
      "main": "Clouds",
      "description": "overcast clouds",
      "icon": "04d"
    }
  ],
  "base": "stations",
  "main": {
    "temp": 280.41,
    "feels_like": 278.67,
    "temp_min": 275.4,
    "temp_max": 284.21,
    "pressure": 1019,
    "humidity": 92
  },
  "visibility": 10000,
  "wind": {
    "speed": 2.57,
    "deg": 320
  },
  "clouds": {
    "all": 100
  },
  "dt": 1706194659,
  "sys": {
    "type": 1,
    "id": 3486,
    "country": "US",
    "sunrise": 1706184283,
    "sunset": 1706219273
  },
  "timezone": -18000,
  "id": 4930956,
  "name": "Boston",
  "cod": 200
}*/