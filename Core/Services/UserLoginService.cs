using WeatherApp.Contracts;
using WeatherApp.Domain.Repositories;
using WeatherApp.Services.Abstractions;
using Mapster;
using WeatherApp.Domain.Entities;
using WeatherApp.Domain.Exceptions;

namespace WeatherApp.Services;

internal sealed class UserLoginService : IUserLoginService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserLoginService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public async Task<IEnumerable<UserLoginDTO>> GetAllUsers(CancellationToken cancellationToken = default)
    {
        var users = await _repositoryManager.UserLoginRepository.GetAllAsync(cancellationToken);
        var usersDTO = users.Adapt<IEnumerable<UserLoginDTO>>();
        return usersDTO;
    }

    public async Task<UserLoginDTO> GetUserById(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserLoginRepository.GetByIdAsync(id, cancellationToken);
        if (user is null)
        {
            throw new UserLoginNotFoundException(id);
        }
        var userLoginDTO = user.Adapt<UserLoginDTO>();
        return userLoginDTO;
    }
    public async Task<UserLoginDTO> GetUserByName(string name, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserLoginRepository.GetByUserNameAsync(name, cancellationToken);
        if (user is null)
        {
            throw new UserLoginNotFoundException(name);
        }
        var userLoginDTO = user.Adapt<UserLoginDTO>();
        return userLoginDTO;
    }

    public async Task<UserLoginDTO> CreateUser(UserLoginForCreationDTO userLoginForCreationDTO, CancellationToken cancellationToken = default)
    {
        var existingUser = await _repositoryManager.UserLoginRepository.GetByUserNameAsync(userLoginForCreationDTO.UserName, cancellationToken);
        if (existingUser is not null)
        {
            throw new UserLoginAlreadyExistsException(existingUser.UserName);
        }
        var user = userLoginForCreationDTO.Adapt<UserLogin>();
        user.CreatedDate = DateTime.Now;
        //user.Id = new Guid(); //not necessary
        _repositoryManager.UserLoginRepository.Insert(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        return user.Adapt<UserLoginDTO>();
    }

    public async Task UpdateUser(Guid id, UserLoginForUpdateDTO userLoginForUpdateDTO, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserLoginRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
        {
            throw new UserLoginNotFoundException(id);
        }

        user.UserName = userLoginForUpdateDTO.UserName;
        user.Password = userLoginForUpdateDTO.Password;
        user.ModifiedDate = DateTime.Now;

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteUser(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserLoginRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
        {
            throw new UserLoginNotFoundException(id);
        }

        _repositoryManager.UserLoginRepository.Remove(user);

        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }


}