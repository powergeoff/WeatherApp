namespace WeatherApp.Core.Domain.ValueObjects;

public record BodyTempScale
{
    public BodyTempScale(int val)
    {
        Value = val;
    }
    public int Value { get; set; }
}