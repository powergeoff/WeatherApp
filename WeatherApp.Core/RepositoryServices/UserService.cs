using Mapster;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.Domain.ValueObjects;
using WeatherApp.Core.DTO;

namespace WeatherApp.Core.RepositoryServices;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<UserDTO> GetUserById(Guid id, CancellationToken cancellationToken = default);
    Task<UserDTO> GetUserBynUserName(string name, CancellationToken cancellationToken = default);
    Task<UserDTO> CreateUser(UserForCreationDTO user, CancellationToken cancellationToken = default);
    Task UpdateUser(Guid id, UserForUpdateDTO user, CancellationToken cancellationToken = default);
    Task DeleteUser(Guid id, CancellationToken cancellationToken = default);
}

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public async Task<UserDTO> CreateUser(UserForCreationDTO userDTO, CancellationToken cancellationToken = default)
    {
        var existingUser = await _repositoryManager.UserRepository.GetByUserNameAsync(userDTO.UserName, cancellationToken);
        if (existingUser is not null)
        {
            throw new Exception("User Name already exists");
        }
        var user = userDTO.Adapt<User>();
        user.CreatedDate = DateTime.Now;
        //encrypt the password
        _repositoryManager.UserRepository.Insert(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        return user.Adapt<UserDTO>();
    }

    public Task DeleteUser(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public async Task<IEnumerable<UserDTO>> GetAllUsers(CancellationToken cancellationToken = default)
    {
        var users = await _repositoryManager.UserRepository.GetAllAsync(cancellationToken);
        var usersDTO = users.Adapt<IEnumerable<UserDTO>>();
        return usersDTO;
    }
    public Task<UserDTO> GetUserById(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<UserDTO> GetUserByLogInUserName(string name, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<UserDTO> GetUserBynUserName(string name, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task UpdateUser(Guid id, UserForUpdateDTO user, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}