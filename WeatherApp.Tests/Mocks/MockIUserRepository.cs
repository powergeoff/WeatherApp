using Moq;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.Domain.ValueObjects;

internal class MockIUserRepository
{

    //dummy data to skirt the database
    public static Mock<IUserRepository> GetMock()
    {
        var mock = new Mock<IUserRepository>();

        var users = new List<User>()
        {
            new User()
            {
                Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                UserName = "User1",
                Password = "Password",
                Role = Roles.User
            },
            new User()
            {
                Id = Guid.Parse("1f8fad5b-d9cb-469f-a165-70867728950e"),
                UserName = "Admin",
                Password = "Password",
                Role = Roles.Admin,
            }
        };


        mock.Setup<Task<IEnumerable<User>>>(m => m.GetAllAsync(CancellationToken.None)).Returns(() => Task.FromResult<IEnumerable<User>>(users));

        mock.Setup<Task<User?>>(m => m.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .Returns((Guid id, CancellationToken token) => Task.FromResult<User?>(users.FirstOrDefault(o => o.Id == id)));

        mock.Setup<Task<User?>>(m => m.GetByUserNameAsync(It.IsAny<string>(), CancellationToken.None))
            .Returns((string name, CancellationToken token) => Task.FromResult<User?>(users.FirstOrDefault(o => o.UserName == name)));

        //finish the rest of the IUserRepository Services here...

        return mock;
    }
}