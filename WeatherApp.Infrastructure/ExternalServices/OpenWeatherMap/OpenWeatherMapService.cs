
using System.Text.Json;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.Services;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;

namespace WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

public interface IOpenWeatherMapService : IGetWeather
{
    void SetCoordinates(double latitude, double longitude);
}

//https://openweathermap.org/current
public class OpenWeatherMapService : IOpenWeatherMapService
{
    private double _latitude;
    private double _longitude;
    private HttpClient _httpClient;
    private IConfigService _config;

    public OpenWeatherMapService(HttpClient httpClient, IConfigService config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public void SetCoordinates(double latitude, double longitude)
    {
        _latitude = latitude;
        _longitude = longitude;
    }
    public async Task<WeatherModel> GetWeather()
    {
        var ret = new WeatherModel();
        try
        {
            var apiKey = _config.APIKey;
            var uri = $"https://api.openweathermap.org/data/2.5/weather?lat={_latitude}&lon={_longitude}&appid={apiKey}&units=imperial";

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