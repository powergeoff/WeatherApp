using Moq;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.RepositoryServices;

internal class MockIExternalServicesManager
{

    //not testing UnitOfWork
    //set up a repository manager 
    //Mock the IUserRepository with dummy data
    //hand it to the REAL UserService to use
    public static Mock<IExternalServicesManager> GetMock()
    {
        var mock = new Mock<IExternalServicesManager>();
        var weatherServiceMock = MockIWeatherService.GetMock();


        mock.Setup(m => m.WeatherService).Returns(() => weatherServiceMock.Object);
        return mock;
    }
}