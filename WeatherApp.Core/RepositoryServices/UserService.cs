using Mapster;
using System.Runtime.CompilerServices;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.Exceptions;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.Domain.ValueObjects;
using WeatherApp.Core.DTO;

namespace WeatherApp.Core.RepositoryServices;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<UserDTO> GetUserById(Guid id, CancellationToken cancellationToken = default);
    Task<UserDTO> CreateUser(UserForCreationDTO userDTO, CancellationToken cancellationToken = default);
    Task<bool> IsValidUser(UserForUpdateDTO userDTO, CancellationToken cancellationToken = default);
    Task UpdateUserName(Guid id, UpdateUserNameDTO userDTO, CancellationToken cancellationToken = default);
    Task UpdatePassword(Guid id, UpdatePasswordDTO userDTO, CancellationToken cancellationToken = default);
    Task UpdateActivityLevel(Guid userId, UpdateActivityLevelDTO activityLevelDTO, CancellationToken cancellationToken = default);
    Task UpdateBodyTemp(Guid userId, UpdateBodyTempLevelDTO bodyTempDTO, CancellationToken cancellationToken = default);
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
            throw new UserAlreadyExistsException(userDTO.UserName);
        }
        var user = userDTO.Adapt<User>();
        user.CreatedDate = DateTime.Now;
        //encrypt the password
        _repositoryManager.UserRepository.Insert(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        return user.Adapt<UserDTO>();
    }

    public async Task DeleteUser(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(id);
        }

        _repositoryManager.UserRepository.Remove(user);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task<IEnumerable<UserDTO>> GetAllUsers(CancellationToken cancellationToken = default)
    {
        var users = await _repositoryManager.UserRepository.GetAllAsync(cancellationToken);
        var usersDTO = users.Adapt<IEnumerable<UserDTO>>();
        return usersDTO;
    }
    public async Task<UserDTO> GetUserById(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);

        if (user is null)
        {
            throw new UserNotFoundException(id);
        }

        return user.Adapt<UserDTO>();
    }

    public async Task UpdateActivityLevel(Guid id, UpdateActivityLevelDTO activityLevelDTO, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);

        if (user is null)
        {
            throw new UserNotFoundException(id);
        }
        user.ActivityLevel = activityLevelDTO.ActivityLevel;

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateBodyTemp(Guid id, UpdateBodyTempLevelDTO bodyTempDTO, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);

        if (user is null)
        {
            throw new UserNotFoundException(id);
        }
        user.BodyTemp = bodyTempDTO.UpdateBodyTemp;

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdatePassword(Guid id, UpdatePasswordDTO userDTO, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);

        if (user is null)
        {
            throw new UserNotFoundException(id);
        }

        user.Password = userDTO.NewPassword;
        user.ModifiedDate = DateTime.Now;

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

    }



    public async Task UpdateUserName(Guid id, UpdateUserNameDTO userDTO, CancellationToken cancellationToken = default)
    {

        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);

        if (user is null)
        {
            throw new UserNotFoundException(id);
        }

        user.UserName = userDTO.NewUserName;
        user.ModifiedDate = DateTime.Now;

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task<bool> IsValidUser(UserForUpdateDTO userDTO, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserRepository.GetByUserNameAsync(userDTO.UserName, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(userDTO.UserName);
        }
        if (user.UserName != userDTO.UserName || user.Password != userDTO.Password)
        {
            throw new InvalidUserException();
        }
        return true;
    }
}