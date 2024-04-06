using WeatherApp.Core.DTO;
using WeatherApp.Infrastructure.Builders;
using WeatherApp.Services.Tests.Models;

public class ClothesDirectorTests
{
    private ClothesDirector _clothesDirector;
    private ClothesForCreationDTO _clothesForCreationDTO;

    /*
    public static Mock<IExternalServicesManager> GetMock()
    {
        var mock = new Mock<IExternalServicesManager>();
        var weatherServiceMock = MockIWeatherService.GetMock();


        mock.Setup(m => m.WeatherService).Returns(() => weatherServiceMock.Object);
        return mock;
    }
    */
    public ClothesDirectorTests()
    {
        var mockExternalServicesManager = MockIExternalServicesManager.GetMock();
        _clothesDirector = new ClothesDirector(mockExternalServicesManager.Object);
        _clothesForCreationDTO = new ClothesForCreationDTO
        {
            Latitude = TestConstants.BostonLatitude,
            Longitude = TestConstants.BostonLongitude
        };
    }

    [Fact]
    public async void DirectorShouldGenerateAllLayers()
    {
        await _clothesDirector.ConstructClothes(_clothesForCreationDTO);
        var fullClothes = _clothesDirector.GetClothes();

        Assert.NotEmpty(fullClothes.BottomLayer);

        Assert.NotEmpty(fullClothes.TopLayers);
    }

    [Fact]
    public async void DirectorShouldGenerateTopLayersOnly()
    {
        await _clothesDirector.ConstructTopLayerOnly(_clothesForCreationDTO);
        var topOnly = _clothesDirector.GetClothes();

        Assert.True(topOnly.BottomLayer == null);

        Assert.NotEmpty(topOnly.TopLayers);
    }
}