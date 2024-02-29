using Mapster;
using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.DTO;

namespace WeatherApp.Core.RepositoryServices;

public interface ILogInService
{
    Task<IEnumerable<LogInDTO>> GetAllLogIns(CancellationToken cancellationToken = default);
    Task<LogInDTO> GetLogInById(Guid id, CancellationToken cancellationToken = default);
    Task<LogInDTO> GetLogInByUserName(string name, CancellationToken cancellationToken = default);
    Task<LogInDTO> CreateLogIn(LogInForCreationDTO logIn, CancellationToken cancellationToken = default);
    Task UpdateLogIn(Guid id, LogInForUpdateDTO logIn, CancellationToken cancellationToken = default);
    Task DeleteLogIn(Guid id, CancellationToken cancellationToken = default);
}

public class LogInService : ILogInService
{

    private readonly IRepositoryManager _repositoryManager;

    public LogInService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    public async Task<LogInDTO> CreateLogIn(LogInForCreationDTO logInDTO, CancellationToken cancellationToken = default)
    {
        var existingLogIn = await _repositoryManager.LoginRepository.GetByUserNameAsync(logInDTO.UserName, cancellationToken);
        if (existingLogIn is not null)
        {
            throw new Exception("User Name already exists");
        }
        var logIn = logInDTO.Adapt<LogIn>();
        logIn.CreatedDate = DateTime.Now;
        _repositoryManager.LoginRepository.Insert(logIn);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        return logIn.Adapt<LogInDTO>();
    }
    public Task DeleteLogIn(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public async Task<IEnumerable<LogInDTO>> GetAllLogIns(CancellationToken cancellationToken = default)
    {
        var logIns = await _repositoryManager.LoginRepository.GetAllAsync(cancellationToken);
        var logInsDTO = logIns.Adapt<IEnumerable<LogInDTO>>();
        return logInsDTO;
    }
    public Task<LogInDTO> GetLogInById(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<LogInDTO> GetLogInByUserName(string name, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task UpdateLogIn(Guid id, LogInForUpdateDTO logIn, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}