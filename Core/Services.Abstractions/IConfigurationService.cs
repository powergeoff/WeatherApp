using System.Text.Json;
using WeatherApp.Contracts;

namespace WeatherApp.Services.Abstractions;

public interface IConfigurationService
{
    JsonSerializerOptions JsonSettings { get; set; }
    string AppVersion { get; set; }
    string ConnectionString { get; set; }
    string DbName { get; set; }
    string APIKey { get; set; }
}