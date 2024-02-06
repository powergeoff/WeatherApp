using System;
using System.Text.Json.Serialization;

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
    public Pants Pants => GetPants(); //should be a collection
    public Tops Top => GetTop(); //should be a collection of Tops
    public Hats? Hat => GetHat();
    public string Information => GetInformation();

    private string GetInformation()
    {
        return $"{_weather.City} Feels like: {_weather.FeelsLikeTemp}, Actual Temp: {_weather.Temperature}";
    }

    public Clothes(WeatherModel weather)
    {
        _weather = weather;
    }

    private Tops GetTop()
    {
        var top = Tops.TShirt;
        if (_weather.FeelsLikeTemp < LayerConstants.HeavyDutytMaxTemp)
        {
            top = Tops.HeavyCoat;
        }
        else if (_weather.FeelsLikeTemp < LayerConstants.JacketMaxTemp)
        {
            top = Tops.Jacket;
        }
        else if (_weather.FeelsLikeTemp < LayerConstants.SweatShirtMaxTemp)
        {
            top = Tops.SweatShirt;
        }
        else if (_weather.FeelsLikeTemp < LayerConstants.LongSleeveTShirtMaxTemp)
        {
            top = Tops.LongSleeveTShirt;
        }
        return top;
    }
    private Hats GetHat()
    {
        var hat = Hats.BaseballHat;
        if (_weather.FeelsLikeTemp < LayerConstants.HeavyDutytMaxTemp)
        {
            hat = Hats.HeavyDutyHat;
        }
        else if (_weather.FeelsLikeTemp < LayerConstants.WinterHatMaxTemp)
        {
            hat = Hats.WinterHat;
        }
        return hat;
    }

    private bool GetGloves()
    {
        return _weather.FeelsLikeTemp < LayerConstants.GlovesMaxTemp;
    }

    private Pants GetPants()
    {
        return _weather.FeelsLikeTemp < LayerConstants.ShortsMaxTemp ? Pants.Pants : Pants.Shorts;
    }
}