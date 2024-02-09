using System;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Xml.Serialization;
using WeatherApp.Services.Configuration;
using WeatherApp.Services.Models;

namespace WeatherApp.Services.OpenWeatherMap;

public interface IOpenWeatherMapService
{
    Task<WeatherModel> GetWeather(double latitude, double longitude);
    Task<WeatherModel> GetWeather(string city, string state);
    Task<WeatherModel> GetWeather(string zipcode);
}

//https://openweathermap.org/current
public class OpenWeatherMapService : IOpenWeatherMapService
{
    private HttpClient _httpClient;
    private IConfigService _config;

    public OpenWeatherMapService(HttpClient httpClient, IConfigService config)
    {
        _httpClient = httpClient;
        _config = config;
    }
    public async Task<WeatherModel> GetWeather(double latitude, double longitude)
    {
        var ret = new WeatherModel();
        try
        {
            var apiKey = _config.APIKey;
            var uri = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=imperial";

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var poco = JsonSerializer.Deserialize<OpenWeatherMapResonse>(result);

            ret.City = poco.name;
            ret.Overall = poco.weather[0].main;
            ret.Description = poco.weather[0].description;
            ret.Humidity = poco.main.humidity;
            ret.Temperature = poco.main.temp;
            ret.FeelsLikeTemp = poco.main.feels_like;
            ret.IsRaining = poco.rain?.nextHourTotal > 0;
            ret.IsSnowing = poco.snow?.nextHourTotal > 0;
            ret.WindSpeed = poco.wind.speed;
            ret.WindDirection = WeatherModel.ConvertWindDirection(poco.wind.deg);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return ret;
    }



    public Task<WeatherModel> GetWeather(string city, string state)
    {
        //get lat and long from city and state
        //call get weather with lat & long
        throw new NotImplementedException();
    }

    public Task<WeatherModel> GetWeather(string zipcode)
    {
        //get lat and long from zipcode
        //call get weather with lat & long
        throw new NotImplementedException();
    }


}