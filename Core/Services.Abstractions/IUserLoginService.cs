
using WeatherApp.Contracts;

namespace WeatherApp.Services.Abstractions;

public interface IUserLoginService
{
    Task<IEnumerable<UserLoginDTO>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<UserLoginDTO> GetUserById(Guid id, CancellationToken cancellationToken = default);
    Task<UserLoginDTO> GetUserByName(string name, CancellationToken cancellationToken = default);
    Task<UserLoginDTO> CreateUser(UserLoginForCreationDTO user, CancellationToken cancellationToken = default);
    Task UpdateUser(Guid id, UserLoginForUpdateDTO user, CancellationToken cancellationToken = default);
    Task DeleteUser(Guid id, CancellationToken cancellationToken = default);
}