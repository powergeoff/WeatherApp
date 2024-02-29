using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Core.Domain.ValueObjects;

public record ActivityLevelScale
{
    public ActivityLevelScale(int val)
    {
        Value = val;
    }
    public int Value { get; set; }
}