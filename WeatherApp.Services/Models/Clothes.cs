using System;

namespace WeatherApp.Services.Models;

public enum Pants
{
    Pants,
    Shorts
}

public enum Tops
{
    TShirt,
    LongSleeveTShirt,
    SweatShirt,
    RainCoat,
    Jacket,
    HeavyCoat
}

public enum Hats
{
    BaseballHat,
    WinterHat,
    HeavyDutyHat
}

public class Clothes
{
    private WeatherModel _weather;

    public bool Gloves => GetGloves();
    public bool RainLayer => _weather.IsRaining;
    public Pants Pants => GetPants();
    public Tops Top => GetTop();
    public Hats? Hat => GetHat();
    public string Information => GetInformation();

    private string GetInformation()
    {
        return $"Feels like: {_weather.FeelsLikeTemp}, Actual Temp: {_weather.Temperature}";
    }

    public Clothes(WeatherModel weather)
    {
        _weather = weather;
    }

    private Tops GetTop()
    {
        var top = Tops.TShirt;
        if (_weather.FeelsLikeTemp < Constants.HeavyDutytMaxTemp)
        {
            top = Tops.HeavyCoat;
        }
        else if (_weather.FeelsLikeTemp < Constants.JacketMaxTemp)
        {
            top = Tops.Jacket;
        }
        else if (_weather.FeelsLikeTemp < Constants.SweaterShirtMaxTemp)
        {
            top = Tops.SweatShirt;
        }
        else if (_weather.FeelsLikeTemp < Constants.LongSleeveTShirtMaxTemp)
        {
            top = Tops.LongSleeveTShirt;
        }
        return top;
    }
    private Hats GetHat()
    {
        var hat = Hats.BaseballHat;
        if (_weather.FeelsLikeTemp < Constants.HeavyDutytMaxTemp)
        {
            hat = Hats.HeavyDutyHat;
        }
        else if (_weather.FeelsLikeTemp < Constants.WinterHatMaxTemp)
        {
            hat = Hats.WinterHat;
        }
        return hat;
    }

    private bool GetGloves()
    {
        return _weather.FeelsLikeTemp < Constants.GlovesMaxTemp;
    }

    private Pants GetPants()
    {
        return _weather.FeelsLikeTemp < Constants.ShortsMaxTemp ? Pants.Pants : Pants.Shorts;
    }
}