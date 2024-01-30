using WeatherApp.Services.Models;

namespace WeatherApp.Services.Tests;

public class WeatherModelTest
{
    //OrdinalDirection result = WeatherModel.ConvertWindDirection(-1); //should wrap back around and not fail
    [Fact]
    public void ConvertWindDirection_ShouldReturnNorth()
    {
        OrdinalDirection result = WeatherModel.ConvertWindDirection(-1); //should wrap back around and not fail
        Assert.True(result.Equals(OrdinalDirection.North));
    }

    [Fact]
    public void ConvertWindDirection_ShouldReturnNorthEast()
    {
        OrdinalDirection result = WeatherModel.ConvertWindDirection(360 + 45); //should wrap back around and not fail
        Assert.True(result.Equals(OrdinalDirection.NorthEast));
    }

    [Fact]
    public void ConvertWindDirection_ShouldReturnNorthWest()
    {
        OrdinalDirection result = WeatherModel.ConvertWindDirection(300);
        Assert.True(result.Equals(OrdinalDirection.NorthWest));
    }
}