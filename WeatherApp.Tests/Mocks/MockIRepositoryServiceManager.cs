using Moq;
using WeatherApp.Core.RepositoryServices;

internal class MockIRepositoryServiceManager
{
    public static Mock<IRepositoryServiceManager> GetMock()
    {
        var mock = new Mock<IRepositoryServiceManager>();

        var mockRepoManager = MockIRepositoryManager.GetMock();

        //hand the real UserService a mockedRepoManager to use with dummy data
        mock.Setup(m => m.UserService).Returns(() => new UserService(mockRepoManager.Object));
        return mock;
    }
}