using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.DTO;

namespace WeatherApp.Core.RepositoryServices;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<UserDTO> GetUserById(Guid id, CancellationToken cancellationToken = default);
    Task<UserDTO> GetUserByLogInUserName(string name, CancellationToken cancellationToken = default);
    Task<UserDTO> CreateUser(UserForCreationDTO user, CancellationToken cancellationToken = default);
    Task UpdateUser(Guid id, UserForUpdateDTO user, CancellationToken cancellationToken = default);
    Task DeleteUser(Guid id, CancellationToken cancellationToken = default);
}

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public Task<UserDTO> CreateUser(UserForCreationDTO user, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task DeleteUser(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<IEnumerable<UserDTO>> GetAllUsers(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<UserDTO> GetUserById(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<UserDTO> GetUserByLogInUserName(string name, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task UpdateUser(Guid id, UserForUpdateDTO user, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}