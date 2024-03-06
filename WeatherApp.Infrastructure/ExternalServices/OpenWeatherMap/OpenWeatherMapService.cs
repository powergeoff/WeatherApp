
using Mapster;
using System.Text.Json;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;

namespace WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

//https://openweathermap.org/current
public class OpenWeatherMapService : IWeatherService
{
    private HttpClient _httpClient;
    private IConfigService _config;

    public OpenWeatherMapService(HttpClient httpClient, IConfigService config)
    {
        _httpClient = httpClient;
        _config = config;
    }


    public async Task<WeatherModel> GetWeather(WeatherForCreationDTO weatherForCreationDTO, CancellationToken cancellationToken)
    {
        var ret = new WeatherModel();
        try
        {
            var apiKey = _config.APIKey;
            var uri = $"https://api.openweathermap.org/data/2.5/weather?lat={weatherForCreationDTO.Latitude}&lon={weatherForCreationDTO.Longitude}&appid={apiKey}&units=imperial";

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
            ret.CreatedTime = DateTime.Now.ToLocalTime();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return ret;
    }
}