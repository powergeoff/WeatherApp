using Moq;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.RepositoryServices;

internal class MockIRepositoryManager
{

    //not testing UnitOfWork
    //set up a repository manager 
    //Mock the IUserRepository with dummy data
    //hand it to the REAL UserService to use
    public static Mock<IRepositoryManager> GetMock()
    {
        var mock = new Mock<IRepositoryManager>();

        var userRepoMock = MockIUserRepository.GetMock();


        mock.Setup(m => m.UserRepository).Returns(() => userRepoMock.Object);
        return mock;
    }
}