


using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Services.Tests.Models;

namespace WeatherApp.Services.Tests;

public class WeatherModelTests
{
    [Fact]
    public async void MockWeather_ShouldNotFail()
    {
        //Arrange
        var weatherDTO = new WeatherForCreationDTO()
        {
            Latitude = TestConstants.BostonLatitude,
            Longitude = TestConstants.BostonLongitude
        };

        //Act
        var weatherServiceMock = MockIWeatherService.GetMock();
        var weatherModel = await weatherServiceMock.Object.GetWeather(weatherDTO);

        //Assert
        Assert.NotEmpty(weatherModel.City);
    }

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