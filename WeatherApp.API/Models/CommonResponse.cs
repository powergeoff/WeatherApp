using System.Collections;

namespace WeatherApp.API.Models;

public class CommonResponse
{
    public bool IsError { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public string? Description { get; set; }
    public IDictionary? Data { get; set; }
}

public class CommonResponse<T>
{
    public bool IsError { get; set; }
    public string? Message { get; set; }
    public string? Description { get; set; }
    public T? Result { get; set; }
}